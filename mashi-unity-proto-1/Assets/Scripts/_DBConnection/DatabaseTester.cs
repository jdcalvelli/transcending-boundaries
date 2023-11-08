using System.Collections;
using System.Collections.Generic;
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

        impactObjects = new ImpactList();
        impactObjects.impacts = new List<Impact>();
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
                impactData = JsonConvert.DeserializeObject<DataJson.Root>(jsonString);
                print("hello");
                StartCoroutine(PopulateData());
            } else
            {
                print("goodbye");
            }
        }
    }

    public IEnumerator PopulateData()
    {
        foreach (DataJson.Impact impact in impactData.list)
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
            yield return null;
        }

        print(impactObjects.impacts[0].desc);
    }

}
