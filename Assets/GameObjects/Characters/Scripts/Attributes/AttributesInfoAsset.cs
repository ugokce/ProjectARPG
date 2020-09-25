using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TargetType
{
    None = 0,
    Player = 10,
    Enemy = 20,
    All = 30
}

public enum EntityType
{
    None = 0,
    Player = 10,
    Enemy = 20,
    Obstacle = 30
}

public enum DamageType
{
    Physical = 0,
    Fire = 10,
    Ice = 20,
    Poison = 30
}

public class AttributesInfoAsset : ScriptableObject
{
    [Header("Base Attributes")]
    public TargetType targetType = TargetType.None;
    public EntityType entityType = EntityType.None;
    [Space]
    public float health = 100f;
    [Range(0, 100)]
    public float moveSpeed = 1f;
    [Range(0, 100)]
    public float attackSpeed = 1f;
    public float gravity = -9.81f;
    public float armor = 0f;

    #region DamageInfos

    public DamageInfo damageInfo = new DamageInfo();

    #endregion
}

[System.Serializable]
public class DamageInfo
{
    public DamageType damageType = DamageType.Physical;

    public Damage regularDamage = new Damage();
    public ElemantalistDamage fireDamage = new ElemantalistDamage();
    public ElemantalistDamage coldDamage = new ElemantalistDamage();
    public ElemantalistDamage poisonDamage = new ElemantalistDamage();

    [Range(0, 1)]
    public float criticalChance = 0f;
    public Damage armorPiece = new Damage();
}

[System.Serializable]
public class Damage
{
    [Range(0, 100)]
    public float value = 1f;
}

[System.Serializable]
public class ElemantalistDamage : Damage
{

}