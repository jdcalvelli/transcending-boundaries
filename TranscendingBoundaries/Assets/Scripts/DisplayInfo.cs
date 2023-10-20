using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayInfo : MonoBehaviour
{
    private EarthNavigator earthNav;
    public TextMeshProUGUI headerText;
    public TextMeshProUGUI bodyText;
    public LandmarkLibrary library;

    public GameObject infoBackButton;

    private void Start()
    {
        earthNav = GetComponent<EarthNavigator>();
    }

    public void DisplayInfobox(int key)
    {
        earthNav.playMode = EarthNavigator.PlayMode.INFO;
        headerText.text = library.landmarkLibrary[key][0];
        bodyText.text = library.landmarkLibrary[key][1];
        infoBackButton.SetActive(true);
    }

    public void CloseInfobox()
    {
        earthNav.playMode = EarthNavigator.PlayMode.IDLE;
        headerText.text = "UN System Topic 1";
        bodyText.text = "More placeholder text~";
        infoBackButton.SetActive(false);
    }
}
