using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopicLibrary : MonoBehaviour
{
    public enum Topic { TOPIC1, TOPIC2, TOPIC3, TOPIC4, TOPIC5, Length };
    public Topic currentTopic;
    public Dictionary<int, List<string>> topicLibrary = new Dictionary<int, List<string>>();

    public EarthNavigator earth;

    // public LandmarkPlacement landmarkPlacer;
    public Image[] buttonImages;
    public TopicSetup[] topics;
    
    private float timeSinceChangeMode;
    private float transitionTime = 10f;

    void Start()
    {
        currentTopic = Topic.TOPIC1;
        timeSinceChangeMode = Time.time;
        buttonImages[(int)currentTopic].color = new Color(1, 1, 1, 0.5f);

        // landmarkPlacer.GenerateRandomLandmarks();

        topicLibrary.Add(0, new List<string> { "Topic 1", "This is a thoughtful introduction to the topic!" });
        topicLibrary.Add(1, new List<string> { "Topic 2", "This is a thoughtful introduction to the topic!" });
        topicLibrary.Add(2, new List<string> { "Topic 3", "This is a thoughtful introduction to the topic!" });
        topicLibrary.Add(3, new List<string> { "Topic 4", "This is a thoughtful introduction to the topic!" });
        topicLibrary.Add(4, new List<string> { "Topic 5", "This is a thoughtful introduction to the topic!" });

        topics[0].EnableLandmarks();
    }

    private void Update()
    {
        if (earth.playMode == EarthNavigator.PlayMode.ROTATING)
        {
            if (Time.time - timeSinceChangeMode > transitionTime)
            {
                buttonImages[(int)currentTopic].color = new Color(1, 1, 1, 1f);
                topics[(int)currentTopic].DisableLandmarks();
                
                if (currentTopic + 1 == Topic.Length) currentTopic = 0;
                else currentTopic += 1;

                topics[(int)currentTopic].EnableLandmarks();
                // landmarkPlacer.DestroyLandmarks();

                buttonImages[(int)currentTopic].color = new Color(1, 1, 1, 0.5f);
                timeSinceChangeMode = Time.time;
            }
        }
    }


}
