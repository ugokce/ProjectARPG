using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributesController : CustomMonoBehaviour
{
    [Space]
    [SerializeField]
    protected AttributesInfoAsset attributesInfoAsset;

    public float Speed { get; set; }
    public float Health { get; set; }
    public float RegularDamage { get; set; }
    public float CriticalChance { get; set; }
    public float ArmorPiece { get; set; }
    public float Armor { get; set; }
    public float Gravity {get; set; }
    public DamageType DamageElement { get; set; }
    public TargetType TargetType { get; set; }

    public virtual float TotalDamage
    {
        get
        {
            return RegularDamage + CriticalChance > Random.Range(0, 1) ? RegularDamage : ArmorPiece;
        }
    }

    public virtual void ResetAllAttributes()
    {
        TargetType = attributesInfoAsset.targetType;

        Speed = attributesInfoAsset.moveSpeed;
        Health = attributesInfoAsset.health;

        RegularDamage = attributesInfoAsset.damageInfo.regularDamage.value;
        CriticalChance = attributesInfoAsset.damageInfo.criticalChance;
        ArmorPiece = attributesInfoAsset.damageInfo.armorPiece.value;
        DamageElement = attributesInfoAsset.damageInfo.damageType;

        Armor = attributesInfoAsset.armor;

        Gravity = attributesInfoAsset.gravity;
    }
}