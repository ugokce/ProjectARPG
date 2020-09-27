using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributesController : CustomMonoBehaviour
{
    [Space]
    [SerializeField]
    protected AttributesInfoAsset attributesInfoAsset;

    public TargetType TargetType { get; set; }

    public float Speed { get; set; }
    public float Health { get; set; }
    public float RegularDamage { get; set; }
    public float AttackSpeed { get; set; }
    public float Armor { get; set; }
    public float Gravity { get; set; }

    public DamageInfo ContactDamageInfo { get; set; }

    public virtual void ResetAllAttributes()
    {
        TargetType = attributesInfoAsset.targetType;

        Speed = attributesInfoAsset.MoveSpeed.Value;
        Health = attributesInfoAsset.Health.Value;
        AttackSpeed = attributesInfoAsset.AttackSpeed.Value;
        RegularDamage = attributesInfoAsset.RegularDamage.Value;
        Armor = attributesInfoAsset.Armor.Value;
        Gravity = attributesInfoAsset.Gravity.Value;

        ContactDamageInfo = new DamageInfo(attributesInfoAsset.contactDamageInfo);
    }
}