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

    public static bool CheckChance(this float chance)
    {
        return Random.Range(0f, 99f) < chance * 100f;
    }

    public static void DoForAll<T>(this IList<T> list, System.Action<T, int> action)
    {
        int count = list.Count;

        for (int n = 0; n < count; n++)
        {
            T item = list[n];
            action(item, n);
        }
    }

    public static void DoForAll<T>(this IList<T> list, System.Action<T> action)
    {
        int count = list.Count;

        for (int n = 0; n < count; n++)
        {
            T item = list[n];
            action(item);
        }
    }
}
