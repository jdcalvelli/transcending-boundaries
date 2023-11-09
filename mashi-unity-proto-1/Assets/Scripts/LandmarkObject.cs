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

    // private TopicLibrary

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

        int orgID = GetComponentInParent<TopicSetup>().GetOrgNumber(); // 
        marker.GetComponent<LandmarkUI>().SetID(GetComponentInParent<TopicSetup>().GetTopicNumber(), orgID);

        markerImage.enabled = false;
        markerButton.enabled = false;
        marker.SetActive(false);

        /*        Debug.Log(Screen.height);
                Debug.Log(Screen.width);
                Debug.Log(Camera.main.pixelWidth);
                Debug.Log(Camera.main.pixelHeight);*/

        GenerateRandomEvents();
    }

    public int GetMarkerOrgID()
    {
        return marker.GetComponent<LandmarkUI>().GetID()[1];
    }

    public void GenerateRandomEvents()
    {
        for (int i = 0; i < 3; i++)
        {
            Vector3 randomLocation = earth.transform.position + earth.GetComponent<SphereCollider>().radius * Random.onUnitSphere * earth.transform.localScale.x;
            var go = Instantiate(eventObjectPrefab, randomLocation, Quaternion.identity, earth.transform);
            eventObjectList.Add(go);
            // go.transform.SetParent(transform, worldPositionStays: false);
        }
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
            markerImage.enabled = false;
            markerButton.enabled = false;
        }
        else
        {
            markerImage.enabled = true;
            markerButton.enabled = true;
        }

        var v = transform.position - Camera.main.transform.position;
        transform.rotation = Quaternion.LookRotation(v);
        
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        markerTransform.anchoredPosition = new Vector2(1920 * pos.x, 1080 * pos.y);
    }

    /*    private void OnDestroy()
        {
            Destroy(marker);
        }*/

    /*    private void OnEnable()
        {
            marker.SetActive(true);
            markerImage.enabled = true;
            markerButton.enabled = true;

        }

        private void OnDisable()
        {
            marker.SetActive(false);
            markerImage.enabled = false;
            markerButton.enabled = false;
        }*/

    public void EnableMarker()
    {
        marker.SetActive(true);
    }

    public void DisableMarker()
    {
        marker.SetActive(false);
    }
}
