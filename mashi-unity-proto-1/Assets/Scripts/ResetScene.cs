using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResetScene : MonoBehaviour
{
    public GameObject infoPanel;
    public TextMeshProUGUI headingBox;
    public TextMeshProUGUI bodyBox;

    public string defaultHeading;
    public string defaultBody;

    public GameObject rotationIndicator;
    public GameObject relevantOrgsSubHeading;
    public GameObject contributionsSubHeading;

    public GameObject returnToOrgListButton;

    public TopicLibrary topicLibrary;
    public OrgFilter orgFilter;
    public EarthNavigator earthNavigator;
    public CameraManagement cameraManagement;

    private float timeOfLastTouch;

    private void Start()
    {
        timeOfLastTouch = Time.time;
    }

    public void ReloadScene()
    {
        infoPanel.SetActive(false);
        headingBox.text = defaultHeading;
        bodyBox.text = defaultBody;
        rotationIndicator.SetActive(true);
        relevantOrgsSubHeading.SetActive(false);
        contributionsSubHeading.SetActive(false);
        returnToOrgListButton.SetActive(false);

        // topicLibrary.ResetLandmarksForCurrentTopic();
        topicLibrary.ResetLandmarks();
        topicLibrary.SetActiveTopic(TopicLibrary.Topic.TOPIC1);
        orgFilter.DisableAllEvents();

        cameraManagement.SetMainCamera();
        earthNavigator.ChangePlayMode(EarthNavigator.PlayMode.ROTATING);
    }

    private void Update()
    {
        if (Input.touchCount == 1)
        {
            timeOfLastTouch = Time.time;
        }

        if (Time.time - timeOfLastTouch > 60)
        {
            if (EarthNavigator.playMode != EarthNavigator.PlayMode.ROTATING) ReloadScene();
            else timeOfLastTouch = Time.time;
        }
    }
}
