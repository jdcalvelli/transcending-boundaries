using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandmarkUI : MonoBehaviour
{
    private GameObject earth;
    private int _topicID;
    private int _orgID;

    void Start()
    {
        earth = GameObject.Find("Earth");
    }

    public void Display()
    {
        earth.GetComponent<DisplayInfo>().DisplayInfobox(_topicID);
    }

    public void Hide()
    {
        earth.GetComponent<DisplayInfo>().CloseInfobox();
    }

    public void SetID(int topicID, int orgID)
    {
        _topicID = topicID;
        _orgID = orgID;
    }

    public List<int> GetID()
    {
        return new List<int>{ _topicID, _orgID };
    }
    
}
