using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopicSetup : MonoBehaviour
{
    public GameObject landmarkPrefab; 

    public string label;
    public List<Impact> impactsByTopic;
    public List<Impact> impactsByOrg;
    public List<string> orgList;
    //public OrgFilter filter; // each topic has its own filter

    [SerializeField]
    private int topicNumber;
    private GameObject earth;

    // for debug
    private int orgMarker = 1;
    public bool doRandomGeneration;

    void Awake()
    {
        impactsByTopic = new List<Impact>();
        impactsByOrg = new List<Impact>();

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
        // testing coordinate placement
        Vector2[] coords = new Vector2[5];
        coords[0] = new Vector2(40.7306f, -73.9352f); // NYC
        coords[1] = new Vector2(41.9028f, 12.4964f); // Rome
        coords[2] = new Vector2(23.8041f, 90.4152f); // Dhaka
        coords[3] = new Vector2(25.0330f, 121.5654f); // Taipei
        coords[4] = new Vector2(31.2304f, 121.4737f); // Shanghai

        foreach (Vector2 coord in coords)
        {
            Vector3 rectCoord = SphericalToRectangular.Convert(earth.GetComponent<SphereCollider>().radius * earth.transform.localScale.x, coord.x, coord.y);
            Vector3 location = earth.transform.position + rectCoord;
            Instantiate(landmarkPrefab, location, Quaternion.identity, transform);
        }
    }

    public GameObject GenerateLandmarkForOrg(string orgName, Vector2 coords)
    {
        Vector3 randomLocation = earth.transform.position + earth.GetComponent<SphereCollider>().radius * earth.transform.localScale.x * Random.onUnitSphere;
        
        // Vector3 rectCoord = SphericalToRectangular.Convert(earth.GetComponent<SphereCollider>().radius * earth.transform.localScale.x, coords.x, coords.y);
        // Vector3 location = earth.transform.position + rectCoord;

        GameObject go = Instantiate(landmarkPrefab, randomLocation, Quaternion.identity, transform);
        go.GetComponent<LandmarkObject>().orgName = orgName;
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
