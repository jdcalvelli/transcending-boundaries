using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TopicLibrary : MonoBehaviour
{
    public enum Topic { TOPIC1, TOPIC2, TOPIC3, Length };
    public static Topic currentTopic;
    public Dictionary<int, List<string>> topicLibrary = new();

    public EarthNavigator earth;

    // public LandmarkPlacement landmarkPlacer;
    public Image[] buttonImages;
    public TopicSetup[] topics;
    public Transform orgButtonGroup;

    public Sprite[] buttonSprites;
    public TextMeshProUGUI[] buttonText;
    public Color[] textColors;

    private float timeSinceChangeMode;
    private float transitionTime = 10f;


    void Start()
    {
        currentTopic = Topic.TOPIC1;
        timeSinceChangeMode = Time.time;
        buttonImages[(int)currentTopic].sprite = buttonSprites[1];
        buttonText[(int)currentTopic].color = textColors[0];

        // landmarkPlacer.GenerateRandomLandmarks();

        topicLibrary.Add(0, new List<string> { "Children", "Every child has the right to health, education and protection, and every society has a stake in expanding childrenÅfs opportunities in life. Yet, around the world, millions of children are denied a fair chance for no reason other than the country, gender or circumstances into which they are born." });
        topicLibrary.Add(1, new List<string> { "Refugees", "This is a thoughtful introduction to the topic!" });
        topicLibrary.Add(2, new List<string> { "Gender", "This is a thoughtful introduction to the topic!" });

        topics[0].EnableLandmarks();
    }

    public void ResetLandmarksForCurrentTopic()
    {
        topics[(int)currentTopic].EnableLandmarks();
    }

    public void SetActiveTopic(Topic newTopic, bool changeLandmarks = true)
    {
        buttonImages[(int)currentTopic].sprite = buttonSprites[0];
        buttonText[(int)currentTopic].color = textColors[1];
        if (changeLandmarks) topics[(int)currentTopic].DisableLandmarks();

        buttonImages[(int)newTopic].sprite = buttonSprites[1];
        buttonText[(int)newTopic].color = textColors[0];
        if (changeLandmarks) topics[(int)newTopic].EnableLandmarks();

        currentTopic = newTopic;
    }

    public void SetupDropdownMenu()
    {
        StartCoroutine(SetupDropdown());
    }

    IEnumerator SetupDropdown()
    {
        foreach (Transform item in orgButtonGroup)
        {
            if (topics[(int)currentTopic].orgList.Contains(item.name)) item.gameObject.SetActive(true);
            else item.gameObject.SetActive(false);
            yield return null;
        }
    }

    public void ResetLandmarks()
    {
        foreach (TopicSetup topic in topics)
        {
            topic.DisableLandmarks();
        }
    }

    private void Update()
    {
        if (EarthNavigator.playMode == EarthNavigator.PlayMode.ROTATING)
        {
            if (Time.time - timeSinceChangeMode > transitionTime)
            {
                Topic newTopic; 
                if (currentTopic + 1 == Topic.Length) newTopic = 0;
                else newTopic = currentTopic + 1;
                SetActiveTopic(newTopic);
                timeSinceChangeMode = Time.time;
            }
        }
    }


}
