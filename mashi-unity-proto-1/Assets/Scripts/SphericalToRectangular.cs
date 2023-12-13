using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphericalToRectangular 
{
    public static Vector3 Convert(float r, float lat, float lon)
    {
        float x = (float)(r * Mathf.Cos(lat * Mathf.Deg2Rad) * Mathf.Cos(lon * Mathf.Deg2Rad));
        float y = (float)(r * Mathf.Cos(lat * Mathf.Deg2Rad) * Mathf.Sin(lon * Mathf.Deg2Rad));
        float z = (float)(r * Mathf.Sin(lat * Mathf.Deg2Rad));

        return new Vector3(x, z, y); // Unity has y up
    }
}
