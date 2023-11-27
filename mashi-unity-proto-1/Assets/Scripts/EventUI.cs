using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EventUI : MonoBehaviour
{
    private GameObject earth;
    private GameObject eventPanel;
    private TextMeshProUGUI heading;
    private TextMeshProUGUI body;
    private Transform linkedTransformObject;

    private string headingText = "";
    private string bodyText = "";

    [SerializeField]
    private GameObject captionTop;
    [SerializeField]
    private GameObject captionBot;
    private GameObject activeCaption;

    // private bool isTextUpdated = false;

    void Start()
    {
        earth = GameObject.Find("Earth");
        eventPanel = earth.GetComponent<DisplayInfo>().eventInfoPanel;
        heading = eventPanel.transform.Find("Heading").GetComponent<TextMeshProUGUI>();
        body = eventPanel.transform.Find("Body").GetComponent<TextMeshProUGUI>();
    }

    public void SetLinkedObject(Transform t)
    {
        linkedTransformObject = t;
    }

    public void SetInfoText(string title, string desc)
    {
        headingText = title;
        bodyText = desc;
    }

    public void SetCaptionPosition()
    {
        if (GetComponent<RectTransform>().anchoredPosition.y > WindowSize.height / 2)
        {
            captionTop.SetActive(true);
            captionBot.SetActive(false);
            activeCaption = captionTop;
        } else
        {
            captionTop.SetActive(false);
            captionBot.SetActive(true);
            activeCaption = captionBot;
        }
    }

    public void CrossFadeCaption(bool fadeIn)
    {
        if (fadeIn) activeCaption.GetComponent<Image>().CrossFadeAlpha(1f, 0.75f, true);
        else activeCaption.GetComponent<Image>().CrossFadeAlpha(0.05f, 0.5f, true);
    }

    public void UpdateEventInfoBox()
    {
        // places the correct content into the event infobox

        earth.GetComponent<DisplayInfo>().OpenEventInfoBox(linkedTransformObject);
        // eventPanel.GetComponent<RectTransform>().position = gameObject.GetComponent<RectTransform>().position + Vector3.up * 200;

        if (headingText == "") headingText = "Title of Recent Event"; 
        if (bodyText == "") bodyText = "A brief description of the event and some context about how it may be a kind of milestone.";

        /*        heading.text = headingText.Substring(0, 40);
                body.text = bodyText.Substring(0, 100);*/
        heading.text = headingText;
        body.text = bodyText;

        // figure out formatting
    }

/*    public void OpenEventInfoBox()
    {
        earth.GetComponent<EarthNavigator>().ChangePlayMode(EarthNavigator.PlayMode.IMPACT);
        earth.GetComponent<CameraManagement>().SetImpactCamera(linkedTransformObject);
        eventPanel.SetActive(true);
    }*/
}
