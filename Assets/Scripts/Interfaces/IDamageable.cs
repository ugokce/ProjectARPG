using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    bool IsDamageable { get; }
    void ApplyDamage(IList<AppliedDamageInfo> appliedDamageInfos, DamageType damageType, GameObject damageSource = null);
    void AddStatus(DamageStatusType damageStatusType);
    void RemoveStatus(DamageStatusType damageStatusType);
}