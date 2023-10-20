using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandmarkLibrary : MonoBehaviour
{
    public Dictionary<int, List<string>> landmarkLibrary = new Dictionary<int, List<string>>();

    void Start()
    {
        landmarkLibrary.Add(1, new List<string> { "Landmark 1", "This is a description!" });
        landmarkLibrary.Add(2, new List<string> { "Landmark 2", "This is also description!" });
    }

}
