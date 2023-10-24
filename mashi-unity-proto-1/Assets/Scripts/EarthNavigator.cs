using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthNavigator : MonoBehaviour
{
    public enum PlayMode { ROTATING, IDLE, RESET, INFO };
    public PlayMode playMode;

    private Vector3 mPrevPos = Vector3.zero;
    private Vector3 mPosDelta = Vector3.zero;

    private float timeOfLastMove;
    private float timeSinceReset;
    private float maxWaitTime = 5.0f;

    private Quaternion restRotation = Quaternion.Euler(new Vector3(0, 0, -23.4f));
    private Quaternion startRotation;

    void Start()
    {
        playMode = PlayMode.ROTATING;
    }

    void Update()
    {
        if (playMode == PlayMode.INFO)
        {
            if (Input.GetMouseButton(0))
            {
                mPosDelta = Input.mousePosition - mPrevPos;
                transform.Rotate(transform.up, -Vector3.Dot(mPosDelta, Camera.main.transform.right), Space.World);
            }
            mPrevPos = Input.mousePosition;
            return;
        }

        if (playMode == PlayMode.IDLE)
        {
            // if rotating along axis, don't need to reset
/*            if (Time.time - timeOfLastMove >= maxWaitTime) playMode = PlayMode.RESET;
            timeSinceReset = 0;
            startRotation = transform.rotation;*/

            if (Time.time - timeOfLastMove >= maxWaitTime) playMode = PlayMode.ROTATING;
        }

        if (playMode == PlayMode.RESET)
        {
            transform.rotation = Quaternion.Slerp(startRotation, restRotation, timeSinceReset);
            timeSinceReset += Time.deltaTime;
            if (timeSinceReset >= 1)
            {
                playMode = PlayMode.ROTATING;
            }
        }

        if (playMode == PlayMode.ROTATING)
        {
            transform.Rotate(new Vector3(0, Time.deltaTime * -10, 0));
        }

        if (playMode != PlayMode.INFO)
        {
            if (Input.GetMouseButton(0))
            {
                playMode = PlayMode.IDLE;
                timeOfLastMove = Time.time;
                mPosDelta = Input.mousePosition - mPrevPos;

                // only keeping rotation along axis
                transform.Rotate(transform.up, -Vector3.Dot(mPosDelta, Camera.main.transform.right), Space.World);
                // transform.Rotate(Camera.main.transform.right, Vector3.Dot(mPosDelta, Camera.main.transform.up), Space.World);
            }

            mPrevPos = Input.mousePosition;
        }
    }
}
