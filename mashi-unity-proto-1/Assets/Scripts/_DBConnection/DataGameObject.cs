using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class TopicMap
{
    public int table2ID;
    public int table1ID;
}

[System.Serializable]
public class TableMap
{
    public int table2ID;
    public int table1ID;
}

[System.Serializable]
public class Topic
{
    public int id;
    public string title;
    public string createdAt;
    public string updatedAt;
    public int numOffices;
    public int numImpacts;
    public List<TableMap> tableMapList;
}

[System.Serializable]
public class OfficeMap
{
    public int table2ID;
    public int table1ID;
}

[System.Serializable]
public class Office
{
    public int id;
    public string title;
    public string createdAt;
    public string updatedAt;
    public int numTopics;
    public int numImpacts;
    public string city;
    public string country;
    public float latitude;
    public float longitude;
    public string desc;
    public List<TableMap> tableMapList;
}

[System.Serializable]
public class ImpactMap
{
    public int table2ID;
    public int table1ID;
}

[System.Serializable]
public class Impact
{
    public int id; 
    public string title;
    public string createdAt;
    public string updatedAt;
    public string desc;
    public int year;
    public int topicId;
    public int officeId;
    public float latitude;
    public float longitude;
    public string country;
    public string city;
    public int numSDGs;
    public List<TableMap> tableMapList;
    public Topic topic;
    public Office office;
}

[System.Serializable]
public class ImpactList
{
    public List<Impact> impacts;
}
