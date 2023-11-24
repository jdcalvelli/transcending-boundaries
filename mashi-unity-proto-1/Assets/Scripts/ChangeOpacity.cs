using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeOpacity : MonoBehaviour
{
    private Image img;
    public 

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EarthNavigator.playMode == EarthNavigator.PlayMode.ROTATING)
        {
            img.color = Color.Lerp(new Color(1, 1, 1, 1), new Color(1, 1, 1, 0), Mathf.Abs(Mathf.Sin(Time.time / 1.5f)));
        } else
        {
            img.color = new Color(1, 1, 1, 0);
        }
    }
}
