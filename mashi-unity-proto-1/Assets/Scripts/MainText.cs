using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainText : MonoBehaviour
{
    public TextMeshProUGUI heading;
    public TextMeshProUGUI body;

    public void SetHeading(string text) {
        heading.text = text;
    }

    public void SetBody(string text)
    {
        body.text = text;
    }

    public void SetHeadingAndBody(string headText, string bodyText)
    {
        SetHeading(headText);
        SetBody(bodyText);
    }

}
