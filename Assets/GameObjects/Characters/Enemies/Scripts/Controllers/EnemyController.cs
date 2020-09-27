using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyController : Enemy
{
    public EnemyAttributesController EnemyAttributesController { get; private set; }
    public EnemyAnimationController AnimationController { get; private set; }

    public Vector3 playerVelocity;

    private void Start()
    {
        EnemyAttributesController = (EnemyAttributesController)AttributesController;
        AnimationController = GetComponent<EnemyAnimationController>();
    }

    #region IDamage

    public override void ApplyDamage(IList<AppliedDamageInfo> appliedDamageInfos, DamageType damageType, GameObject damageSource = null)
    {
        base.ApplyDamage(appliedDamageInfos, damageType, damageSource);

        appliedDamageInfos.DoForAll(appliedDamageInfo =>
        {
            // TODO: Handle status effect damages
        });

        float damageAmount = appliedDamageInfos.Sum(x => x.amount);

        EnemyAttributesController.Health -= damageAmount;

        if (EnemyAttributesController.Health < 1)
        {
            Die();
        }
    }

    public override void AddStatus(DamageStatusType damageStatusType)
    {
        base.AddStatus(damageStatusType);

        // TODO: Add status effect logic
    }

    public override void RemoveStatus(DamageStatusType damageStatusType)
    {
        base.RemoveStatus(damageStatusType);

        // TODO: Remove status effect logic
    }

    #endregion

    public override void Die()
    {
        base.Die();
    }
}
