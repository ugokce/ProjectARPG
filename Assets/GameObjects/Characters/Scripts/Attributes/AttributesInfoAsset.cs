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
    FirstImpact = 0
}

public enum DamageStatusType
{
    None = 0
}

public class AttributesInfoAsset : ScriptableObject, IAttributesInfoAsset, ISerializationCallbackReceiver
{
    [Header("Base Attributes")]
    public TargetType targetType = TargetType.None;

    [SerializeField]
    [Range(MIN_HEALTH_ATTRIBUTE_VALUE, MAX_HEALTH_ATTRIBUTE_VALUE)]
    float health = 100f;
    [SerializeField]
    [Range(MIN_ATTRIBUTE_VALUE, MAX_ATTRIBUTE_VALUE)]
    float attackSpeed = MIN_ATTRIBUTE_VALUE;
    [SerializeField]
    [Range(MIN_ATTRIBUTE_VALUE, MAX_ATTRIBUTE_VALUE)]
    int moveSpeed = MIN_ATTRIBUTE_VALUE;
    [SerializeField]
    [Range(MIN_ATTRIBUTE_VALUE, MAX_ATTRIBUTE_VALUE)]
    int regularDamage = MIN_ATTRIBUTE_VALUE;
    [SerializeField]
    [Range(MIN_ATTRIBUTE_VALUE, MAX_ATTRIBUTE_VALUE)]
    int armor = MIN_ATTRIBUTE_VALUE;
    [SerializeField]
    [Range(MIN_GRAVITY_ATTRIBUTE_VALUE, MAX_GRAVITY_ATTRIBUTE_VALUE)]
    float gravity = -9.81f;

    public DamageInfo contactDamageInfo;

    public RangedIntValue MoveSpeed { get; private set; }
    public RangedIntValue RegularDamage { get; private set; }
    public RangedIntValue Armor { get; private set; }
    public RangedFloatValue Health { get; private set; }
    public RangedFloatValue AttackSpeed { get; private set; }
    public RangedFloatValue Gravity { get; private set; }

    public virtual void OnBeforeSerialize()
    {
        // Leave it empty!
    }

    public virtual void OnAfterDeserialize()
    {
        Health = new RangedFloatValue(health, MIN_HEALTH_ATTRIBUTE_VALUE, MAX_HEALTH_ATTRIBUTE_VALUE);
        AttackSpeed = new RangedFloatValue(attackSpeed, MIN_ATTRIBUTE_VALUE, MAX_ATTRIBUTE_VALUE);
        MoveSpeed = new RangedIntValue(moveSpeed, MIN_ATTRIBUTE_VALUE, MAX_ATTRIBUTE_VALUE);
        RegularDamage = new RangedIntValue(regularDamage, MIN_ATTRIBUTE_VALUE, MAX_ATTRIBUTE_VALUE);
        Armor = new RangedIntValue(armor, MIN_ATTRIBUTE_VALUE, MAX_ATTRIBUTE_VALUE);
        Gravity = new RangedFloatValue(gravity, MIN_GRAVITY_ATTRIBUTE_VALUE, MAX_GRAVITY_ATTRIBUTE_VALUE);
    }

    #region IAttributes

    int IAttributesInfoAsset.MinAttributeValue => MIN_ATTRIBUTE_VALUE;
    int IAttributesInfoAsset.MaxAttributeValue => MAX_ATTRIBUTE_VALUE;

    public EntityType EntityType { get; protected set; }

    #endregion

    #region Const Values Range

    public const int MIN_ATTRIBUTE_VALUE = 1;
    public const int MAX_ATTRIBUTE_VALUE = 10;

    public const float MIN_HEALTH_ATTRIBUTE_VALUE = 1;
    public const float MAX_HEALTH_ATTRIBUTE_VALUE = 10000;

    public const float MIN_GRAVITY_ATTRIBUTE_VALUE = -100;
    public const float MAX_GRAVITY_ATTRIBUTE_VALUE = 100;

    #endregion
}