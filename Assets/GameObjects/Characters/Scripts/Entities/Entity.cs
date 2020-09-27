using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DamageController))]
public class Entity : CustomMonoBehaviour, IDamageable
{
    public AttributesController AttributesController { get; protected set; }

    public static List<Entity> Entities { get; set; } = new List<Entity>();

    public bool IsDamageable { get; protected set; } = true;
    public bool IsFollowable() => isFollowable;

    bool isFollowable = true;

    protected virtual void Awake()
    {
        AttributesController = GetComponent<AttributesController>();
    }

    protected virtual void OnEnable()
    {
        Entities.Add(this);
    }

    protected virtual void OnDisable()
    {
        Entities.Remove(this);
    }

    #region IDamage

    public virtual void ApplyDamage(IList<AppliedDamageInfo> appliedDamageInfos, DamageType damageType, GameObject damageSource = null)
    {
        
    }

    public virtual void AddStatus(DamageStatusType damageStatusType)
    {
        
    }

    public virtual void RemoveStatus(DamageStatusType damageStatusType)
    {
        
    } 

    #endregion

    public virtual void Die()
    {
        
    }
}