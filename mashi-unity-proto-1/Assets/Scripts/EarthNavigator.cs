using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthNavigator : MonoBehaviour
{
    public enum PlayMode { ROTATING, IDLE, RESET, TOPIC, IMPACT };
    public static PlayMode playMode;

    // for mouse input
    private Vector3 mPrevPos = Vector3.zero;
    private Vector3 mPosDelta = Vector3.zero;

    private float timeOfLastMove;
    private float maxWaitTime = 2.5f;

    public OrgFilter orgFilter;

    void Start()
    {
        playMode = PlayMode.ROTATING;
    }

    public void ChangePlayMode(PlayMode mode)
    {
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
/*            if (Input.GetMouseButton(0))
            {
                GetComponent<DisplayInfo>().CloseEventInfoPanel();
                playMode = PlayMode.TOPIC;
            }*/
            return;
        }

        if (playMode == PlayMode.IDLE)
        {
            if (Time.time - timeOfLastMove >= maxWaitTime) playMode = PlayMode.ROTATING;
        }

        if (playMode == PlayMode.ROTATING)
        {
            transform.Rotate(new Vector3(0, Time.deltaTime * -10, 0));
        }
        
        // for testing with mouse input
/*        if (Input.GetMouseButton(0))
        {
            mPosDelta = Input.mousePosition - mPrevPos;
            transform.Rotate(transform.up, -Vector3.Dot(mPosDelta, Camera.main.transform.right), Space.World);
            timeOfLastMove = Time.time;
            if (playMode != PlayMode.TOPIC) playMode = PlayMode.IDLE;
        }
        mPrevPos = Input.mousePosition;*/

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
                        transform.Rotate(transform.up, -touch.deltaPosition.x / 10, Space.World);
                        timeOfLastMove = Time.time;
                    }
                }
            }
        }
    }
}
