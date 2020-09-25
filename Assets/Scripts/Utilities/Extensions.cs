using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static bool IsNull<T>(this T unityObject) where T : class
    {
        return unityObject == null || unityObject.Equals(null);
    }

    public static T GetScriptableObject<T>(string scriptableObjectFileName) where T : ScriptableObject
    {
        T scriptableObject = Resources.Load<T>(scriptableObjectFileName);

        return scriptableObject ? scriptableObject : null;
    }
}
