using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributesInfoAsset : ScriptableObject
{
    [Space]
    [Header("Base Attributes")]
    public float health = 100f;
    [Range(0, 100)]
    public float moveSpeed = 1f;
    [Range(0, 100)]
    public float attackSpeed = 1f;
    public float gravity = -9.81f;
    public DamageInfo damageInfo = new DamageInfo();
}

[System.Serializable]
public class DamageInfo
{
    public Damage regularDamage = new Damage();
    public ElemantalistDamage fireDamage = new ElemantalistDamage();
    public ElemantalistDamage coldDamage = new ElemantalistDamage();
    public ElemantalistDamage poisonDamage = new ElemantalistDamage();
}

[System.Serializable]
public class Damage
{
    [Range(0, 100)]
    public float amount = 1f;
}

[System.Serializable]
public class ElemantalistDamage : Damage
{

}