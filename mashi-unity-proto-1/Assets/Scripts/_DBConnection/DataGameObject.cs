using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Topic
{
    public int id;
    public string title;
}

[System.Serializable]
public class Office
{
    public int id;
    public string title;
}

[System.Serializable]
public class Impact
{
    public int id; 
    public string title;
    public string createdAt;
    public string updatedAt;
    public string desc;
    public string loc;
    public int year;
    public int topicId;
    public int officeId;
    public Topic topic;
    public Office office;
}

[System.Serializable]
public class ImpactList
{
    public List<Impact> impacts;
}
