using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LandmarkRotation : MonoBehaviour
{
    public GameObject markerPrefab;

    private GameObject marker;
    private RectTransform markerTransform;
    private Image markerImage;
    private Button markerButton;

    void Start()
    {
        marker = Instantiate(markerPrefab, GameObject.Find("Canvas").transform);
        markerTransform = marker.GetComponent<RectTransform>();
        markerImage = marker.GetComponent<Image>();
        markerButton = marker.GetComponent<Button>();

        // assign random key
        // TODO: edit this for a particular dataset
        marker.GetComponent<DisplayMarkerInfo>().idKey = Random.Range(1, 3);
        marker.SetActive(false);

/*        Debug.Log(Screen.height);
        Debug.Log(Screen.width);
        Debug.Log(Camera.main.pixelWidth);
        Debug.Log(Camera.main.pixelHeight);*/
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
