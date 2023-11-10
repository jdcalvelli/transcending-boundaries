using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using System.Linq;

public class DatabaseRetrievalTest : MonoBehaviour
{
    public DataJson.Root impactData;
    public ImpactList impactObjects;
    public bool isDataPopulating = false;

    public static List<string> officeList = new();
    public OrgFilter orgFilter;
    public TopicSetup childrenTopic;

    void Start()
    {
        StartCoroutine(DatabaseSingleton.Instance.GetImpacts("children"));

        impactObjects = new ImpactList
        {
            impacts = new List<Impact>()
        };

        // TestDeserialization();
    }

    private void TestDeserialization()
    {
        string jsonString = File.ReadAllText("Assets/Data/sample.txt");
        impactData = JsonConvert.DeserializeObject<DataJson.Root>(jsonString);
        print(impactData.list[0].Topic.Title);
    }

    private void PrepareImpacts()
    {
        officeList = impactObjects.impacts.Select(i => i.office.title).Distinct().ToList();
        // orgFilter.dropdown.AddOptions(officeList);     // temporary add options
        foreach (string s in officeList)
        {
            orgFilter.AddLibraryEntry(s);
            var landmarkGameObject = childrenTopic.GenerateLandmarkForOrg(orgFilter.orgLibrary.Count - 1);
            List<Impact> impactsByOrg = impactObjects.impacts.Where(i => i.office.title == s).ToList();
            StartCoroutine(AddImpactsToOrg(landmarkGameObject.GetComponent<LandmarkObject>(), impactsByOrg));
        }
    }

    IEnumerator AddImpactsToOrg(LandmarkObject landmark, List<Impact> impacts)
    {
        foreach (Impact impact in impacts)
        {
            landmark.GenerateImpactByOrg(impact.title, impact.desc);
            yield return null;
        }
        childrenTopic.EnableLandmarks();
    }

    private void Update()
    {
        if (!isDataPopulating)
        {
            if (DatabaseSingleton.text != null)
            {
                isDataPopulating = true;
                string jsonString = DatabaseSingleton.text;
                print(jsonString);
                impactData = 
                    JsonConvert.DeserializeObject<DataJson.Root>
                    (
                        jsonString, 
                        new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore } 
                    );
                StartCoroutine(PopulateData());
            } 
        }
    }

    public IEnumerator PopulateData()
    {
        foreach (DataJson.Impact impact in impactData.list)
        {
            try
            {
                Impact newImpact = new();
                newImpact.id = impact.Id;
                newImpact.title = impact.Title;
                newImpact.createdAt = impact.CreatedAt;
                newImpact.updatedAt = impact.UpdatedAt;
                newImpact.desc = impact.Desc;
                newImpact.loc = impact.Loc;
                newImpact.year = impact.Year;
                newImpact.topicId = impact.TopicId;
                newImpact.officeId = impact.OfficeId;

                newImpact.topic = new Topic();
                newImpact.office = new Office();

                Topic newTopic = new();
                newTopic.id = impact.Topic.Id;
                newTopic.title = impact.Topic.Title;
                newImpact.topic = newTopic;

                Office newOffice = new();
                newOffice.id = impact.Office.Id;
                newOffice.title = impact.Office.Title;
                newImpact.office = newOffice;

                impactObjects.impacts.Add(newImpact);
            }
            catch
            {
                print("Missing data?");
            }
            yield return null;
        }
        PrepareImpacts();
    }

}
