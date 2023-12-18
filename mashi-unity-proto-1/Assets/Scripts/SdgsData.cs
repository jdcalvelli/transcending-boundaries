using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SdgsData : MonoBehaviour
{
    public Sprite[] sdgSprites;
    public static Dictionary<string, (int, int, int)> idToSDGs;
    public DatabaseRetrievalTest data;
    private ImpactList impacts;

    void Start()
    {
        StartCoroutine(WaitForImpactList());
    }

    public void FillDictionary()
    {
        idToSDGs = new();
        idToSDGs.Add(impacts.impacts[0].title, (2, 4, 3));
        idToSDGs.Add(impacts.impacts[1].title, (10, 3, 7));
        idToSDGs.Add(impacts.impacts[2].title, (2, 9, 10));
        idToSDGs.Add(impacts.impacts[3].title, (2, 16, 10));
        idToSDGs.Add(impacts.impacts[4].title, (2, 16, 10));
        idToSDGs.Add(impacts.impacts[5].title, (2, 5, 9));
        idToSDGs.Add(impacts.impacts[6].title, (2, 9, 3));
        idToSDGs.Add(impacts.impacts[7].title, (2, 3, 4));
        idToSDGs.Add(impacts.impacts[8].title, (1, 2, 0));
        idToSDGs.Add(impacts.impacts[9].title, (1, 3, 9));
        idToSDGs.Add(impacts.impacts[10].title, (3, 7, 10));
        idToSDGs.Add(impacts.impacts[11].title, (3, 7, 9));
        idToSDGs.Add(impacts.impacts[12].title, (1, 0, 2));
        idToSDGs.Add(impacts.impacts[13].title, (1, 9, 16));
        idToSDGs.Add(impacts.impacts[14].title, (2, 9, 10));
        idToSDGs.Add(impacts.impacts[15].title, (2, 9, 15));
        idToSDGs.Add(impacts.impacts[16].title, (9, 0, 10));
        idToSDGs.Add(impacts.impacts[17].title, (10, 9, 2));
        idToSDGs.Add(impacts.impacts[18].title, (15, 9, 10));
        idToSDGs.Add(impacts.impacts[19].title, (9, 15, 7));
        idToSDGs.Add(impacts.impacts[20].title, (5, 16, 15));
        idToSDGs.Add(impacts.impacts[21].title, (16, 15, 9));
        idToSDGs.Add(impacts.impacts[22].title, (1, 9, 6));
        idToSDGs.Add(impacts.impacts[23].title, (9, 1, 0));
        idToSDGs.Add(impacts.impacts[24].title, (4, 9, 7));
        idToSDGs.Add(impacts.impacts[25].title, (2, 4, 7));
        idToSDGs.Add(impacts.impacts[26].title, (9, 7, 4));
        idToSDGs.Add(impacts.impacts[27].title, (2, 4, 9));
        idToSDGs.Add(impacts.impacts[28].title, (4, 9, 15));
        idToSDGs.Add(impacts.impacts[29].title, (4, 9, 15));
        idToSDGs.Add(impacts.impacts[30].title, (4, 2, 9));
        idToSDGs.Add(impacts.impacts[31].title, (4, 2, 10));
        idToSDGs.Add(impacts.impacts[32].title, (4, 9, 2));
        idToSDGs.Add(impacts.impacts[33].title, (4, 2, 15));
    }

    IEnumerator WaitForImpactList()
    {
        while (!data.isDataFinishedRetrieving) yield return null;
        impacts = data.allImpacts;
        FillDictionary();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
