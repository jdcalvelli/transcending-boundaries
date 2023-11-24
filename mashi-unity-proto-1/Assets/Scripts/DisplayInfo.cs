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
    public TMP_Dropdown dropdown;
    public GameObject eventInfoPanel;

    public GameObject infoBackButton;

    private void Start()
    {
        earthNav = GetComponent<EarthNavigator>();
    }

    public void DisplayInfobox(int topicID)
    {
        earthNav.ChangePlayMode(EarthNavigator.PlayMode.TOPIC);
        headerText.text = library.topicLibrary[topicID][0];
        bodyText.text = library.topicLibrary[topicID][1];

        // update, change sprite
        library.buttonImages[(int)library.currentTopic].color = new Color(1, 1, 1, 1);
        library.currentTopic = (TopicLibrary.Topic)topicID;
        library.buttonImages[topicID].color = new Color(1, 1, 1, 0.5f);
        infoBackButton.SetActive(true);
        OpenDropdown();
    }

    public void DisplayOrgInfo(int orgID)
    {
        SetDropdownMenu(orgID);
    }

    public void CloseDropdown()
    {
        // if (dropdown.gameObject.activeSelf) dropdown.gameObject.SetActive(false);
        if (dropdown.gameObject.activeSelf) dropdown.gameObject.GetComponent<OrgFilter>().DisableAllEvents(true);
    }

    public void OpenDropdown()
    {
        if (!dropdown.gameObject.activeSelf) dropdown.gameObject.SetActive(true);
    }

    public void SetDropdownMenu(int key)
    {
        dropdown.value = key;
    }

    public void CloseInfobox()
    {
        earthNav.ChangePlayMode(EarthNavigator.PlayMode.IDLE);
        headerText.text = "The UN System";
        bodyText.text = "" +
            "Did you know that the UN is actually comprised of over 100 organizations, entities, " +
            "and agencies working together all over the world? \n\nClick on one of the topics on the " +
            "right to learn about how the UN is addressing these global issues.";

        infoBackButton.SetActive(false);
        eventInfoPanel.SetActive(false);
        CloseDropdown();
    }

    public void CloseEventInfoPanel()
    {
        eventInfoPanel.SetActive(false);
    }
}
