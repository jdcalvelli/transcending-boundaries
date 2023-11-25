using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OrgContributions : MonoBehaviour
{
    public TextMeshProUGUI contributionsText;

    public void SetText(string text)
    {
        contributionsText.text = text;
    }

}
