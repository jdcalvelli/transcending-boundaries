using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSdgs : MonoBehaviour
{
    public Image top;
    public Image mid;
    public Image bot;
    public SdgsData data;

    public void SetSDGImages((int, int, int) sdgs)
    {
        top.sprite = data.sdgSprites[sdgs.Item1];
        mid.sprite = data.sdgSprites[sdgs.Item2];
        bot.sprite = data.sdgSprites[sdgs.Item3];
    }
}
