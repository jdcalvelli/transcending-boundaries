using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayTopicInfo : MonoBehaviour
{
    private GameObject earth;
    public TopicSetup topic;
    public TopicLibrary topicLibrary;
    public Transform orgButtonGroup;

    void Start()
    {
        earth = GameObject.Find("Earth");
        
    }

    public void Display()
    {
        topicLibrary.SetActiveTopic((TopicLibrary.Topic)topic.GetTopicNumber());
        earth.GetComponent<DisplayInfo>().DisplayInfobox(topic.GetTopicNumber());
        // print(TopicLibrary.currentTopic);
    }

    public void Hide()
    {
        earth.GetComponent<DisplayInfo>().CloseInfobox();
        earth.GetComponent<DisplayInfo>().eventInfoPanel.SetActive(false);
    }



}
