using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayMarkerInfo : MonoBehaviour
{
    private GameObject earth;
    public int idKey;

    void Start()
    {
        earth = GameObject.Find("Earth");
    }

    public void Display()
    {
        earth.GetComponent<DisplayInfo>().DisplayInfobox(idKey);
    }

    public void Hide()
    {
        earth.GetComponent<DisplayInfo>().CloseInfobox();
    }


    
}
