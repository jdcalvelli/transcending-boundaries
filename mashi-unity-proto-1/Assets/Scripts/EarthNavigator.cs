using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthNavigator : MonoBehaviour
{
    public enum PlayMode { ROTATING, IDLE, RESET, TOPIC, IMPACT };
    public static PlayMode playMode;

    private float timeOfLastMove;
    private float maxWaitTime = 2.5f;

    public OrgFilter orgFilter;
    public GameObject topicButtonGroup;
    public GameObject homeButton;

    private float rotationSpeed = 10f;

    [SerializeField]
    private float dragCoefficient;

    void Start()
    {
        playMode = PlayMode.ROTATING;
    }

    public void ChangePlayMode(PlayMode mode)
    {
        if (mode == PlayMode.ROTATING || mode == PlayMode.IDLE)
        {
            topicButtonGroup.SetActive(true);
            homeButton.SetActive(false);
        } else
        {
            topicButtonGroup.SetActive(false);
            homeButton.SetActive(true);
        }

        if (mode == PlayMode.IMPACT)
        {
            orgFilter.currentOrg.HideEvents();
            orgFilter.currentOrg.DisableMarker();
        } else if (playMode == PlayMode.IMPACT && mode == PlayMode.TOPIC)
        {
            orgFilter.currentOrg.ShowEvents();
            orgFilter.currentOrg.EnableMarker();
        }

        playMode = mode;
    }

    void Update()
    {
        if (playMode == PlayMode.IMPACT)
        {
            return;
        }

        if (playMode == PlayMode.IDLE)
        {
            if (Time.time - timeOfLastMove >= maxWaitTime) playMode = PlayMode.ROTATING;
        }

        if (playMode == PlayMode.ROTATING)
        {
            transform.Rotate(new Vector3(0, Time.deltaTime * -rotationSpeed, 0));
        }

        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform.CompareTag("Globe"))
                {
                    if (touch.phase == TouchPhase.Moved)
                    {
                        transform.Rotate(transform.up, -touch.deltaPosition.x / dragCoefficient, Space.World);
                        timeOfLastMove = Time.time;
                    }
                }
            }
        }
    }
}
