using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using System.Linq;

public class DatabaseRetrievalTest : MonoBehaviour
{
    public DataJson.ImpactList impactData;
    public ImpactList allImpacts;

    public bool isDataPopulating = false;
    public bool isDataFinishedRetrieving = false;

    public OrgFilter orgFilter;

    public TopicSetup[] topics;
    public TopicSetup childrenTopic;

    void Start()
    {
        StartCoroutine(DatabaseSingleton.Instance.GetDatabaseDump());

        allImpacts = new ImpactList
        {
            impacts = new List<Impact>()
        };

        // TestDeserialization();
    }

    private void TestDeserialization()
    {
        string jsonString = File.ReadAllText("Assets/Data/message.txt");
        impactData = JsonConvert.DeserializeObject<DataJson.ImpactList>(jsonString);
    }

    private void PrepareImpacts()
    {
        foreach (TopicSetup topic in topics)
        {
            topic.impactsByTopic = allImpacts.impacts.Where(i => i.topic.title == topic.label).ToList();
            PrepareImpactsByOffice(topic);
        }
        isDataFinishedRetrieving = true;
    }

    private void PrepareImpactsByOffice(TopicSetup topic)
    {
        topic.orgList = topic.impactsByTopic.Select(i => i.office.title).Distinct().ToList();

        foreach (string officeName in topic.orgList)
        {
            topic.impactsByOrg = topic.impactsByTopic.Where(i => i.office.title == officeName).ToList();

            (bool officeExists,  GameObject button) = orgFilter.AddLibraryEntry(officeName, topic.impactsByOrg[0].office.desc);

            Vector2 orgLocation = new(topic.impactsByOrg[0].office.latitude, topic.impactsByOrg[0].office.longitude);
            GameObject landmarkGameObject = topic.GenerateLandmarkForOrg(officeName.ToUpper(), orgLocation);

            landmarkGameObject.GetComponent<LandmarkObject>().SetOrgButton(button.GetComponent<OrgButtonParams>());
            landmarkGameObject.name = officeName;

            StartCoroutine(AddImpactsToOrg(landmarkGameObject.GetComponent<LandmarkObject>(), topic.impactsByOrg));
        }
    }

    IEnumerator AddImpactsToOrg(LandmarkObject landmark, List<Impact> impacts)
    {
        foreach (Impact impact in impacts)
        {
            landmark.GenerateImpactByOrg(impact);
            yield return null;
        }

        topics[(int)TopicLibrary.currentTopic].EnableLandmarks();
    }

    private void Update()
    {
        if (!isDataPopulating)
        {
            if (DatabaseSingleton.DatabaseDump != null)
            {
                isDataPopulating = true;
                string jsonString = DatabaseSingleton.DatabaseDump;
                print(jsonString);
                impactData = 
                    JsonConvert.DeserializeObject<DataJson.ImpactList>
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
        foreach (DataJson.Impact impact in impactData.AllImpacts)
        {
            try
            {
                Impact newImpact = new();
                newImpact.id = impact.Id;
                newImpact.title = impact.Title;
                newImpact.createdAt = impact.CreatedAt;
                newImpact.updatedAt = impact.UpdatedAt;
                newImpact.desc = impact.Desc;
                newImpact.year = impact.Year;
                newImpact.topicId = impact.TopicId;
                newImpact.officeId = impact.OfficeId;
                newImpact.latitude = impact.Latitude;
                newImpact.longitude = impact.Longitude;
                newImpact.country = impact.Country;
                newImpact.city = impact.City;
                newImpact.numSDGs = impact.NumSDGs;

                newImpact.tableMapList = new List<TableMap>();
                newImpact.topic = new Topic();
                newImpact.office = new Office();

                foreach (DataJson.TableMap tableMap in impact.TableMapList)
                {
                    TableMap newTableMap = new();
                    newTableMap.table1ID = tableMap.Table1ID;
                    newTableMap.table2ID = tableMap.Table2ID;
                    newImpact.tableMapList.Add(newTableMap);
                }

                Topic newTopic = new();
                newTopic.id = impact.Topic.Id;
                newTopic.title = impact.Topic.Title;
                newTopic.createdAt = impact.Topic.CreatedAt;
                newTopic.updatedAt = impact.Topic.UpdatedAt;
                newTopic.numImpacts = impact.Topic.NumImpacts;
                newTopic.numOffices = impact.Topic.NumOffices;
                newTopic.tableMapList = new List<TableMap>();
                newImpact.topic = newTopic;

                foreach (DataJson.TableMap tableMap in impact.Topic.TableMapList)
                {
                    TableMap newTableMap = new();
                    newTableMap.table1ID = tableMap.Table1ID;
                    newTableMap.table2ID = tableMap.Table2ID;
                    newTopic.tableMapList.Add(newTableMap);
                }

                Office newOffice = new();
                newOffice.id = impact.Office.Id;
                newOffice.title = impact.Office.Title;
                newOffice.createdAt = impact.Office.CreatedAt;
                newOffice.updatedAt = impact.Office.UpdatedAt;
                newOffice.numImpacts = impact.Office.NumImpacts;
                newOffice.numTopics = impact.Office.NumTopics;
                newOffice.city = impact.Office.City;
                newOffice.country = impact.Office.Country;
                newOffice.latitude = impact.Office.Latitude;
                newOffice.longitude = impact.Office.Longitude;
                newOffice.desc = impact.Office.Desc;
                newOffice.tableMapList = new List<TableMap>();
                newImpact.office = newOffice;

                foreach (DataJson.TableMap tableMap in impact.Office.TableMapList)
                {
                    TableMap newTableMap = new();
                    newTableMap.table1ID = tableMap.Table1ID;
                    newTableMap.table2ID = tableMap.Table2ID;
                    newOffice.tableMapList.Add(newTableMap);
                }

                allImpacts.impacts.Add(newImpact);
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
