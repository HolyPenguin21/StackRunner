using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods
{
    public static void ResetRotation(this Transform transform)
    {
        transform.localRotation = Quaternion.Euler(0,0,0);
    }
}
