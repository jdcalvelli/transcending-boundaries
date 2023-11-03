using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseTester : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // this is just a holdover script to testt that the api works
        // we dont have parsing yet, thats next
        StartCoroutine(DatabaseSingleton.Instance.GetImpacts("children"));
    }
}
