using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventUI : MonoBehaviour
{
    private GameObject earth;
    private GameObject eventPanel;

    void Start()
    {
        earth = GameObject.Find("Earth");
        eventPanel = earth.GetComponent<DisplayInfo>().eventInfoPanel;
    }

    public void UpdateEventInfoBox()
    {
        OpenEventInfoBox();
        eventPanel.GetComponent<RectTransform>().position = gameObject.GetComponent<RectTransform>().position + Vector3.up * 200;
    }

    public void CloseEventInfoBox()
    {
        eventPanel.SetActive(false);
    }

    public void OpenEventInfoBox()
    {
        eventPanel.SetActive(true);
    }
}
