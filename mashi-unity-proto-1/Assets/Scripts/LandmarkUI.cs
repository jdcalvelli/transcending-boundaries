using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandmarkUI : MonoBehaviour
{
    private GameObject earth;
    private int _topicID;
    private int _orgID;
    private OrgButtonParams orgButton;

    void Start()
    {
        earth = GameObject.Find("Earth");
    }

    // change display info script for new UI
    public void Display()
    {
        earth.GetComponent<DisplayInfo>().DisplayInfobox(_topicID);
        earth.GetComponent<DisplayInfo>().DisplayOrgInfo(_orgID);
    }

    public void Hide()
    {
        earth.GetComponent<DisplayInfo>().CloseInfobox();
    }

    public void SetButton(OrgButtonParams button)
    {
        orgButton = button;
    }

    public void ClickOnButton()
    {
        orgButton.StartFilterOrgButton();
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
