using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrgNameToData : MonoBehaviour
{
    public List<Sprite> orgLogoList;
    public static Dictionary<string, Sprite> nameToSprite = new();
    public static Dictionary<string, string> nameToDescription = new();
    public static Dictionary<int, string> indexToName = new();

    private void Start()
    {
        StartCoroutine(FillSpriteDictionary());
    }

    IEnumerator FillSpriteDictionary()
    {
        foreach (Sprite logo in orgLogoList)
        {
            nameToSprite.Add(logo.name, logo);
            yield return null;
        }
    }
}
