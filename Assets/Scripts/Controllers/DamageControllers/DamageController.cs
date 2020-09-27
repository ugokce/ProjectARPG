using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : CustomMonoBehaviour
{
    public GameObject LatestDamageSource { get; private set; }
    public DamageInfo LatestDamageInfo { get; private set; }

    IDamageable damageable;

    List<AppliedDamageInfo> appliedDamageInfos = new List<AppliedDamageInfo>();
    ObjectPool<AppliedDamageInfo> appliedDamageInfoPool = new ObjectPool<AppliedDamageInfo>();

    void Awake()
    {
        damageable = GetComponentInParent<IDamageable>();
    }

    public void AddDamage(DamageInfo damageInfo, GameObject damageSource)
    {
        LatestDamageSource = damageSource;
        LatestDamageInfo = damageInfo;

        HandleDamage(ref damageInfo);
    }

    public void HandleDamage(ref DamageInfo damageInfo)
    {
        if (damageable.IsNull() || !damageable.IsDamageable)
            return;

        ReturnAppliedDamageInfosToPool();

        float criticalDamageFactor = 1;
        bool criticalHit = false;

        if (damageInfo.criticalChance > 0 && damageInfo.criticalChance.CheckChance())
        {
            criticalDamageFactor = 2;
            criticalHit = true;
        }

        if (damageInfo.regularDamage > 0)
        {
            var appliedDamageInfo = new AppliedDamageInfo();
            appliedDamageInfo.SetValues(damageInfo.regularDamage * criticalDamageFactor, DamageStatusType.None, criticalHit);
            appliedDamageInfos.Add(appliedDamageInfo);
        }

        damageable.ApplyDamage(appliedDamageInfos, DamageType.FirstImpact, LatestDamageSource);
    }

    void ReturnAppliedDamageInfosToPool()
    {
        if (appliedDamageInfos.Count > 0)
        {
            appliedDamageInfoPool.Push(appliedDamageInfos);
            appliedDamageInfos.Clear();
        }
    }
}

public class AppliedDamageInfo
{
    public float amount;
    public DamageStatusType damageStatusType;
    public bool criticalHit;

    public void SetValues(float amount, DamageStatusType damageStatusType, bool criticalHit)
    {
        this.amount = amount;
        this.damageStatusType = damageStatusType;
        this.criticalHit = criticalHit;
    }
}