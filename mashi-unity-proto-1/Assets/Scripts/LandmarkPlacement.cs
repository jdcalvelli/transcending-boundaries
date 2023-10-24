using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandmarkPlacement : MonoBehaviour
{
    // deprecated after adding individual topic GameObjects

    public GameObject landmarkPrefab;


    void Start()
    {
        // GenerateRandomLandmarks();
    }

    public void GenerateRandomLandmarks()
    {
        for (int i = 0; i < 10; i++) {
            Vector3 randomLocation = transform.position + GetComponent<SphereCollider>().radius * Random.onUnitSphere * transform.localScale.x;
            Instantiate(landmarkPrefab, randomLocation, Quaternion.identity, transform);
        } 
    }

    public void DestroyLandmarks()
    {
        StartCoroutine(DestroyAllChildren());
    }

    IEnumerator DestroyAllChildren()
    {
        while (transform.childCount > 0)
        {
            Destroy(transform.GetChild(0).gameObject);
            yield return null;
        }
        GenerateRandomLandmarks();
    }

}