using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopicSetup : MonoBehaviour
{
    public GameObject landmarkPrefab;
    public bool doRandomGeneration;
    [SerializeField]
    private int topicNumber;
    private GameObject earth;

    // placeholder for designating organizations
    private int orgMarker = 1;

    void Awake()
    {
        earth = transform.parent.gameObject;
        if (doRandomGeneration) GenerateRandomLandmarks();
    }

    void Update()
    {
        
    }

    // temporary
    public int GetTempOrgNumber()
    {
        int temp = orgMarker;
        orgMarker += 1;
        return temp;
    }

    public int GetTopicNumber()
    {
        return topicNumber;
    }

    public void SetTopicNumber(int num)
    {
        topicNumber = num;
    }

    public void GenerateRandomLandmarks()
    {
        for (int i = 0; i < 5; i++)
        {
            Vector3 randomLocation = earth.transform.position + earth.GetComponent<SphereCollider>().radius * earth.transform.localScale.x * Random.onUnitSphere;
            Instantiate(landmarkPrefab, randomLocation, Quaternion.identity, transform);
        }
    }

    public GameObject GenerateLandmarkForOrg(int orgNumber)
    {
        Vector3 randomLocation = earth.transform.position + earth.GetComponent<SphereCollider>().radius * earth.transform.localScale.x * Random.onUnitSphere;
        GameObject go = Instantiate(landmarkPrefab, randomLocation, Quaternion.identity, transform);
        go.GetComponent<LandmarkObject>().childrenOrgID = orgNumber;
        return go;
    }

    public void EnableLandmarks()
    {
        StartCoroutine(EnableAllChildrenInTransform());
    }

    public void DisableLandmarks()
    {
        StartCoroutine(DisableAllChildrenInTransform());
    }

    IEnumerator DisableAllChildrenInTransform()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.GetComponent<LandmarkObject>().DisableMarker();
            yield return null;
        }
    }

    IEnumerator EnableAllChildrenInTransform()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.GetComponent<LandmarkObject>().EnableMarker();
            yield return null;
        }
    }
}
