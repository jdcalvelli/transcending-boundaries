using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class DatabaseTester : MonoBehaviour
{
    public DataJson.Root impactData;
    public ImpactList impactObjects;
    public bool isDataPopulating = false;

    void Start()
    {
        // this is just a holdover script to testt that the api works
        // we dont have parsing yet, thats next
        StartCoroutine(DatabaseSingleton.Instance.GetImpacts("children"));

        impactObjects = new ImpactList
        {
            impacts = new List<Impact>()
        };

        TestDeserialization();
    }

    private void TestDeserialization()
    {
        string jsonString = File.ReadAllText("Assets/Data/sample.txt");
        impactData = JsonConvert.DeserializeObject<DataJson.Root>(jsonString);
        print(impactData.list[0].Topic.Title);
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
                newTopic.id = impact.Office.Id;
                newTopic.title = impact.Office.Title;
                newImpact.office = newOffice;

                impactObjects.impacts.Add(newImpact);
            }
            catch
            {
                print("Missing data?");
            }
            yield return null;
        }

        print(impactObjects.impacts[0].desc);
    }

}
