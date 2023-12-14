using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrgNameToData : MonoBehaviour
{
    public List<Sprite> orgLogoList;
    public static Dictionary<string, Sprite> nameToSprite = new();

    public static Dictionary<string, string> nameToDescription = new();
    public static Dictionary<int, string> indexToName = new();

    // different name2desc for each topic
/*    public static Dictionary<string, string> nameToDescription1 = new();
    public static Dictionary<int, string> indexToName1 = new();

    public static Dictionary<string, string> nameToDescription2 = new();
    public static Dictionary<int, string> indexToName2 = new();

    public static Dictionary<string, string> nameToDescription3 = new();
    public static Dictionary<int, string> indexToName3 = new();*/

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

/*    public static Dictionary<string, string> Name2DescByTopic(TopicLibrary.Topic topic)
    {
        switch (topic)
        {
            case TopicLibrary.Topic.TOPIC1:
                return nameToDescription1;
            case TopicLibrary.Topic.TOPIC2:
                return nameToDescription2;
            case TopicLibrary.Topic.TOPIC3:
                return nameToDescription3;
            default:
                return nameToDescription1;
        }
    }

    public static Dictionary<int, string> Index2NameByTopic(TopicLibrary.Topic topic)
    {
        switch (topic)
        {
            case TopicLibrary.Topic.TOPIC1:
                return indexToName1;
            case TopicLibrary.Topic.TOPIC2:
                return indexToName2;
            case TopicLibrary.Topic.TOPIC3:
                return indexToName3;
            default:
                return indexToName1;
        }
    }*/
}
