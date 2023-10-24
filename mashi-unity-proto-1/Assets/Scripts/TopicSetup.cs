using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopicSetup : MonoBehaviour
{
    public GameObject landmarkPrefab;
    private GameObject earth;


    void Awake()
    {
        earth = transform.parent.gameObject;
        GenerateRandomLandmarks();
    }

    void Update()
    {
        
    }

    public void GenerateRandomLandmarks()
    {
        for (int i = 0; i < 10; i++)
        {
            Vector3 randomLocation = earth.transform.position + earth.GetComponent<SphereCollider>().radius * Random.onUnitSphere * earth.transform.localScale.x;
            Instantiate(landmarkPrefab, randomLocation, Quaternion.identity, transform);
        }
    }

    public void EnableLandmarks()
    {
        StartCoroutine(EnableAllChildren());
    }

    public void DisableLandmarks()
    {
        StartCoroutine(DisableAllChildren());
    }

    IEnumerator DisableAllChildren()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.GetComponent<LandmarkRotation>().DisableMarker();
            // child.gameObject.SetActive(false);
            yield return null;
        }
    }

    IEnumerator EnableAllChildren()
    {
        foreach (Transform child in transform)
        {
            // child.gameObject.SetActive(true);
            child.gameObject.GetComponent<LandmarkRotation>().EnableMarker();
            yield return null;
        }
    }
}
