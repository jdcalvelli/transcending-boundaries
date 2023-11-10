using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EventUI : MonoBehaviour
{
    private GameObject earth;
    private GameObject eventPanel;
    private TextMeshProUGUI heading;
    private TextMeshProUGUI body;

    private string headingText = "";
    private string bodyText = "";

    private bool isTextUpdated = false;

    void Start()
    {
        earth = GameObject.Find("Earth");
        eventPanel = earth.GetComponent<DisplayInfo>().eventInfoPanel;
        heading = eventPanel.transform.Find("Heading").GetComponent<TextMeshProUGUI>();
        body = heading.transform.Find("Body").GetComponent<TextMeshProUGUI>();
    }

    public void SetInfoText(string title, string desc)
    {
        headingText = title;
        bodyText = desc;
    }

    public void UpdateEventInfoBox()
    {
        OpenEventInfoBox();
        eventPanel.GetComponent<RectTransform>().position = gameObject.GetComponent<RectTransform>().position + Vector3.up * 200;

        if (headingText == "") headingText = "Title of Recent Event"; 
        if (bodyText == "") bodyText = "A brief description of the event and some context about how it may be a kind of milestone."; 

        heading.text = headingText.Substring(0, 20);
        body.text = bodyText.Substring(0, 100);
    }

    public void CloseEventInfoBox()
    {
        eventPanel.SetActive(false);
    }

    public void OpenEventInfoBox()
    {
        eventPanel.SetActive(true);
        earth.GetComponent<EarthNavigator>().ChangePlayMode(EarthNavigator.PlayMode.IMPACT);
    }
}
