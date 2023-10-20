using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandmarkPlacement : MonoBehaviour
{
    public GameObject landmarkPrefab;

    void Start()
    {
        GenerateRandomLandmarks();
    }

    public void GenerateRandomLandmarks()
    {
        for (int i = 0; i < 10; i++) {
            Vector3 randomLocation = transform.position + Random.onUnitSphere * GetComponent<SphereCollider>().radius;
            Instantiate(landmarkPrefab, randomLocation, Quaternion.identity, transform);
        } 
    }
}