using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandmarkUI : MonoBehaviour
{
    private GameObject earth;
    private int _topicID;
    private int _orgID;
    private string _orgName;
    private OrgButtonParams orgButton;

    void Start()
    {
        earth = GameObject.Find("Earth");
    }

    public void Hide()
    {
        earth.GetComponent<DisplayInfo>().CloseInfobox();
    }

    public void SetButton(OrgButtonParams button)
    {
        orgButton = button;
    }

    public void Display()
    {
        orgButton.StartFilterOrgButton();
    }

    public void SetID(int topicID, string orgName)
    {
        _topicID = topicID;
        //_orgID = orgID;
        _orgName = orgName;
    }

    public List<int> GetID()
    {
        return new List<int>{ _topicID, _orgID };
    }
    
}
