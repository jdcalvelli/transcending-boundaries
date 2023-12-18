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

    private string eventTitle = "";
    private string eventDesc = "";
    private string eventCity = "";
    private string eventCountry = "";

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
            eventMarkerImage.CrossFadeAlpha(0.05f, 0.5f, true);
            eventMarkerButton.enabled = false;
        }
        else
        {
            eventMarkerImage.CrossFadeAlpha(1, 0.75f, true);
            eventMarkerButton.enabled = true;
        }

        var v = transform.position - Camera.main.transform.position;
        transform.rotation = Quaternion.LookRotation(v);

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        eventMarkerTransform.anchoredPosition = new Vector2(WindowSize.width * pos.x, WindowSize.height * pos.y);
        eventMarker.GetComponent<EventUI>().SetCaptionPosition();
        eventMarker.GetComponent<EventUI>().CrossFadeCaption(eventMarkerButton.enabled);
        eventMarker.GetComponent<EventUI>().SetLinkedObject(transform);
    }

    public void SetEventDetails(Impact impact)
    {
        eventTitle = impact.title;
        eventDesc = impact.desc;
        eventCity = impact.city;
        eventCountry = impact.country;
        StartCoroutine(WaitToSetText(impact));
    }

    IEnumerator WaitToSetText(Impact impact)
    {
        while (eventMarker == null) yield return null; // doesn't work smoothly anymore? null object reference ~35 times 
        // yield return new WaitForSeconds(3.0f);
        eventMarker.GetComponent<EventUI>().SetInfoText(impact);
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
