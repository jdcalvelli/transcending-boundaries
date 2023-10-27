using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayTopicInfo : MonoBehaviour
{
    private GameObject earth;
    public int idKey; // connect this to the TopicSetup number instead

    void Start()
    {
        earth = GameObject.Find("Earth");
    }

    public void Display()
    {
        earth.GetComponent<DisplayInfo>().DisplayInfobox(idKey);
        // Are we expecting the same organizations to be represented for each topic? 
        // If so, dropdown menu will be the same, the links will just be different. 
    }

    public void Hide()
    {
        earth.GetComponent<DisplayInfo>().CloseInfobox();
        earth.GetComponent<DisplayInfo>().eventInfoPanel.SetActive(false);
    }



}
