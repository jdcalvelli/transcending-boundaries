using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public class DatabaseSingleton : MonoBehaviour
{
    // private set for Instance so that we cant override elsewhere
    public static DatabaseSingleton Instance { get; private set; }

    // built in unity event func
    private void Awake()
    {
        // insure singleton pattern
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        }
    }

    // creating a coroutine bc this is an async activity
    public IEnumerator GetImpacts(string topicArea)
    {
        // creating the request itself
        UnityWebRequest request = UnityWebRequest.Get(
            $"https://noco.jdcalvelli.me/api/v1/db/data/v1/p364wcopjitnzvx/impacts?where=(topic-area, eq, {topicArea})"
            );
        
        // setting the header with the required authentication
        // i gitignored the APIKEY.cs file within the _DBConnection folder
        // so everyone can make their own file in that folder called APIKEY.cs
        // and create a public static string on the class called APIKey
        request.SetRequestHeader("xc-token", APIKEY.APIKey);

        // send the request
        yield return request.SendWebRequest();
        
        // insure no error
        switch (request.result)
        {
            case UnityWebRequest.Result.ConnectionError:
                print("connection error");
                break;
            case UnityWebRequest.Result.ProtocolError:
                print("protocol error");
                break;
            default:
                // if there isnt an error, keep it rolling
                // take the json object and serialize to class
                print(JsonConvert.SerializeObject(request.downloadHandler.text));
                break;
        }
    }
}
