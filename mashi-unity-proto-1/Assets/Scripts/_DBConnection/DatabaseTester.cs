using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class DatabaseTester : MonoBehaviour
{
    public DataJson.ImpactList impactData;
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
                impactData = JsonConvert.DeserializeObject<DataJson.ImpactList>(jsonString);
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
        foreach (DataJson.Impact impact in impactData.Impacts)
        {
            Impact newImpact = new();
            newImpact.id = impact.id;
            newImpact.title = impact.title;
            newImpact.createdAt = impact.createdAt;
            newImpact.updatedAt = impact.updatedAt;
            newImpact.desc = impact.desc;
            newImpact.loc = impact.loc;
            newImpact.year = impact.year;
            newImpact.topicId = impact.topicId;
            newImpact.officeId = impact.officeId;

            newImpact.topic = new Topic();
            newImpact.office = new Office();

            Topic newTopic = new();
            newTopic.id = impact.Topic.id;
            newTopic.title = impact.Topic.title;
            newImpact.topic = newTopic;

            Office newOffice = new();
            newTopic.id = impact.Office.id;
            newTopic.title = impact.Office.title;
            newImpact.office = newOffice;

            impactObjects.impacts.Add(newImpact);
            yield return null;
        }

        print(impactObjects.impacts[0].desc);
    }

}
