using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayInfo : MonoBehaviour
{
    private EarthNavigator earthNav;
    public TextMeshProUGUI headerText;
    public TextMeshProUGUI bodyText;
    public TopicLibrary library;
    public GameObject eventInfoPanel;

    // public GameObject infoBackButton;

    public GameObject topicButtonGroup;

    private void Start()
    {
        earthNav = GetComponent<EarthNavigator>();
    }

    public void DisplayInfobox(int topicID)
    {
        earthNav.ChangePlayMode(EarthNavigator.PlayMode.TOPIC);
        headerText.text = library.topicLibrary[topicID][0];
        bodyText.text = library.topicLibrary[topicID][1];

        library.SetActiveTopic((TopicLibrary.Topic)topicID, false);

        // infoBackButton.SetActive(true);
    }

    public void CloseInfobox()
    {
        earthNav.ChangePlayMode(EarthNavigator.PlayMode.IDLE);
        headerText.text = "The UN System";
        bodyText.text = "" +
            "Did you know that the UN is actually comprised of over 100 organizations, entities, " +
            "and agencies working together all over the world? \n\nClick on one of the topics on the " +
            "right to learn about how the UN is addressing these global issues.";

        // infoBackButton.SetActive(false);
        eventInfoPanel.SetActive(false);
    }

    public void OpenEventInfoBox(Transform impactPin)
    {
        earthNav.ChangePlayMode(EarthNavigator.PlayMode.IMPACT);
        earthNav.GetComponent<CameraManagement>().SetImpactCamera(impactPin);
        topicButtonGroup.SetActive(false);
        eventInfoPanel.SetActive(true);
    }

    public void CloseEventInfoPanel()
    {
        if (eventInfoPanel.activeSelf) eventInfoPanel.SetActive(false);
        earthNav.GetComponent<CameraManagement>().SetMainCamera();
        earthNav.ChangePlayMode(EarthNavigator.PlayMode.TOPIC);
    }
}
