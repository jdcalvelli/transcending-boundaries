using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TopicLibrary : MonoBehaviour
{
    public enum Topic { TOPIC1, TOPIC2, TOPIC3, Length };
    public Topic currentTopic;
    public Dictionary<int, List<string>> topicLibrary = new Dictionary<int, List<string>>();

    public EarthNavigator earth;

    // public LandmarkPlacement landmarkPlacer;
    public Image[] buttonImages;
    public TopicSetup[] topics;

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

    private void Update()
    {
        if (EarthNavigator.playMode == EarthNavigator.PlayMode.ROTATING)
        {
            if (Time.time - timeSinceChangeMode > transitionTime)
            {
                buttonImages[(int)currentTopic].sprite = buttonSprites[0];
                buttonText[(int)currentTopic].color = textColors[1];
                topics[(int)currentTopic].DisableLandmarks();
                
                if (currentTopic + 1 == Topic.Length) currentTopic = 0;
                else currentTopic += 1;

                topics[(int)currentTopic].EnableLandmarks();
                // landmarkPlacer.DestroyLandmarks();

                buttonImages[(int)currentTopic].sprite = buttonSprites[1];
                buttonText[(int)currentTopic].color = textColors[0];
                timeSinceChangeMode = Time.time;
            }
        }
    }


}
