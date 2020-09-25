using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : CustomMonoBehaviour, IDamageable
{
    public AttributesController AttributesController { get; protected set; }

    public static List<Entity> Entities { get; set; } = new List<Entity>();

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

    public virtual void ApplyDamage(float damage, DamageType damageType)
    {
    }
}