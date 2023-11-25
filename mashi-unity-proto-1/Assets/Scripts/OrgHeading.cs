using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OrgHeading : MonoBehaviour
{
    public TextMeshProUGUI topicAndOrgText;
    public Image orgLogo;
    public Button[] topicButtons;
    public TopicLibrary library;

    public void ButtonSetup(string topic, string org)
    {
        topicAndOrgText.text = $"{topic} / {org}";
        orgLogo.sprite = OrgNameToData.nameToSprite[org];
    }

    public void ReturnToTopic()
    {
        topicButtons[(int)library.currentTopic].onClick.Invoke();
    }


}
