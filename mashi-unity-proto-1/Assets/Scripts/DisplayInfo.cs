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

    public void DisplayInfobox(int key)
    {
        earthNav.playMode = EarthNavigator.PlayMode.INFO;
        headerText.text = library.topicLibrary[key][0];
        bodyText.text = library.topicLibrary[key][1];

        library.buttonImages[(int)library.currentTopic].color = new Color(1, 1, 1, 1);
        library.currentTopic = (TopicLibrary.Topic)key;
        library.buttonImages[key].color = new Color(1, 1, 1, 0.5f);
        infoBackButton.SetActive(true);
        OpenDropdown();
    }

    public void CloseDropdown()
    {
        if (dropdown.gameObject.activeSelf) dropdown.gameObject.SetActive(false);
    }

    public void OpenDropdown()
    {
        if (!dropdown.gameObject.activeSelf) dropdown.gameObject.SetActive(true);
    }

    public void CloseInfobox()
    {
        earthNav.playMode = EarthNavigator.PlayMode.IDLE;
        headerText.text = "The UN System";
        bodyText.text = "" +
            "Did you know that the UN is actually comprised of over 100 organizations, entities, " +
            "and agencies working together all over the world? \n\nClick on one of the topics on the " +
            "right to learn about how the UN is addressing these global issues.";

        infoBackButton.SetActive(false);
        eventInfoPanel.SetActive(false);
        CloseDropdown();
    }
}
