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
    public static string DatabaseDump;

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
    // this dumps the entire database as it currently stands
    // this should be called at some regular interval to keep the data as recent as possible
    // we also need to do the database sorting on the unity side, not based on the api calls themselves
    public IEnumerator GetDatabaseDump()
    {
        // creating the request itself
        UnityWebRequest request = UnityWebRequest.Get(
            $"https://noco.jdcalvelli.me/api/v1/db/data/v1/p364wcopjitnzvx/impacts?nested[un-offices][fields]=*&nested[topic-areas][fields]=*&limit=50)"
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
                DatabaseDump = request.downloadHandler.text;
                break;
        }
    }
}
