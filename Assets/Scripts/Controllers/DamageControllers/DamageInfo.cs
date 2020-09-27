using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct DamageInfo
{
    public float regularDamage;
    [Range(0f, 1f)]
    public float criticalChance;

    public float TotalDamage => regularDamage;

    public DamageInfo(DamageInfo damageInfo)
    {
        regularDamage = damageInfo.regularDamage;
        criticalChance = damageInfo.criticalChance;
    }

    public static DamageInfo operator *(DamageInfo damageInfo, float factor)
    {
        damageInfo.RescaleValues(factor);

        return damageInfo;
    }

    public static DamageInfo operator *(float factor, DamageInfo damageInfo)
    {
        damageInfo.RescaleValues(factor);

        return damageInfo;
    }

    void RescaleValues(float factor)
    {
        regularDamage *= Mathf.FloorToInt(factor) == 0 ? 1 : Mathf.FloorToInt(factor);
        criticalChance *= factor;
    }
}