using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LandmarkObject : MonoBehaviour
{
    public GameObject markerPrefab;
    public GameObject eventObjectPrefab;

    private GameObject marker;
    private RectTransform markerTransform;
    private Image markerImage;
    private Button markerButton;

    // temp
    public int childrenOrgID = 50;
    private OrgButtonParams orgButton;

    private GameObject earth;
    public List<GameObject> eventObjectList = new List<GameObject>();

    private void Awake()
    {
        earth = GameObject.Find("Earth");
    }

    void Start()
    {
        marker = Instantiate(markerPrefab, GameObject.Find("Canvas").transform);
        markerTransform = marker.GetComponent<RectTransform>();
        markerImage = marker.GetComponent<Image>();
        markerButton = marker.GetComponent<Button>();

        markerImage.enabled = true;
        markerButton.enabled = false;

        // checking if topic is children
        if (!transform.parent.CompareTag("Children"))
        {
            int orgID = GetComponentInParent<TopicSetup>().GetTempOrgNumber(); // 
            marker.GetComponent<LandmarkUI>().SetID(GetComponentInParent<TopicSetup>().GetTopicNumber(), orgID);
            GenerateRandomEvents();
            marker.SetActive(false);
        } else
        {
            StartCoroutine(SetOrgInfo());
        }
    }

    public void SetOrgButton(OrgButtonParams button)
    {
        orgButton = button;
    }

    IEnumerator SetOrgInfo()
    {
        while (childrenOrgID == 50) { 
            yield return null;
        }
        while (orgButton == null)
        {
            yield return null;
        }

        marker.GetComponent<LandmarkUI>().SetID(GetComponentInParent<TopicSetup>().GetTopicNumber(), childrenOrgID);
        marker.GetComponent<LandmarkUI>().SetButton(orgButton);
        marker.SetActive(false);
    }

    public int GetMarkerOrgID()
    {
        return marker.GetComponent<LandmarkUI>().GetID()[1];
    }

    public void GenerateRandomEvents()
    {
        for (int i = 0; i < 3; i++)
        {
            Vector3 randomLocation = earth.transform.position + earth.GetComponent<SphereCollider>().radius * earth.transform.localScale.x * Random.onUnitSphere;
            var go = Instantiate(eventObjectPrefab, randomLocation, Quaternion.identity, earth.transform);
            eventObjectList.Add(go);
            // go.transform.SetParent(transform, worldPositionStays: false);
        }
    }

    //temp
    public void GenerateImpactByOrg(string title, string desc)
    {
        Vector3 randomLocation = earth.transform.position + earth.GetComponent<SphereCollider>().radius * earth.transform.localScale.x * Random.onUnitSphere;
        var go = Instantiate(eventObjectPrefab, randomLocation, Quaternion.identity, earth.transform);
        go.GetComponent<EventObject>().SetEventDetails(title, desc);
        eventObjectList.Add(go);
    }

    public void ShowEvents()
    {
        StartCoroutine(ShowEventMarkers());
    }

    IEnumerator ShowEventMarkers()
    {
        foreach (GameObject go in eventObjectList)
        {
            go.GetComponent<EventObject>().EnableEventMarker();
            // child.gameObject.GetComponent<EventObject>().EnableEventMarker();
            yield return null;
        }
    }

    public void HideEvents()
    {
        StartCoroutine(HideEventMarkers());
    }

    IEnumerator HideEventMarkers()
    {
        foreach (GameObject go in eventObjectList)
        {
            go.GetComponent<EventObject>().DisableEventMarker();
            // child.gameObject.GetComponent<EventObject>().DisableEventMarker();
            yield return null;
        }
    }

    void Update()
    {
        // Debug.Log(transform.position.z);

        if (!marker.activeSelf) return;

        if (transform.position.z > -2f)
        {
            markerImage.CrossFadeAlpha(0.05f, 0.5f, true);
            markerButton.enabled = false;
        }
        else
        {
            // why is this transition instantaneous? 
            markerImage.CrossFadeAlpha(1, 0.75f, true);
            markerButton.enabled = true;
        }

        var v = transform.position - Camera.main.transform.position;
        transform.rotation = Quaternion.LookRotation(v);
        
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        markerTransform.anchoredPosition = new Vector2(WindowSize.width * pos.x, WindowSize.height * pos.y);
    }

    public void EnableMarker()
    {
        marker.SetActive(true);
    }

    public void DisableMarker()
    {
        marker.SetActive(false);
    }
}
