using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventObject : MonoBehaviour
{
    public GameObject eventMarkerPrefab;

    private GameObject eventMarker;
    private RectTransform eventMarkerTransform;
    private Image eventMarkerImage;
    private Button eventMarkerButton;

    private GameObject earth;

    private void Awake()
    {
        earth = GameObject.Find("Earth");
    }

    void Start()
    {
        eventMarker = Instantiate(eventMarkerPrefab, GameObject.Find("Canvas").transform);
        eventMarkerTransform = eventMarker.GetComponent<RectTransform>();
        eventMarkerImage = eventMarker.GetComponent<Image>();
        eventMarkerButton = eventMarker.GetComponent<Button>();

        // int orgID = GetComponentInParent<TopicSetup>().GetOrgNumber(); // 
        // eventMarker.GetComponent<EventUI>().SetID(GetComponentInParent<TopicSetup>().GetTopicNumber(), orgID);

        eventMarker.SetActive(false);
    }

    void Update()
    {
        if (!eventMarker.activeSelf) return;

        if (transform.position.z > -2f)
        {
            eventMarkerImage.enabled = false;
            eventMarkerButton.enabled = false;
        }
        else
        {
            eventMarkerImage.enabled = true;
            eventMarkerButton.enabled = true;
        }

        var v = transform.position - Camera.main.transform.position;
        transform.rotation = Quaternion.LookRotation(v);

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        eventMarkerTransform.anchoredPosition = new Vector2(1920 * pos.x, 1080 * pos.y);
    }

    public void EnableEventMarker()
    {
        eventMarker.SetActive(true);
    }

    // need to turn off event markers!
    public void DisableEventMarker()
    {
        eventMarker.SetActive(false);
    }
}
