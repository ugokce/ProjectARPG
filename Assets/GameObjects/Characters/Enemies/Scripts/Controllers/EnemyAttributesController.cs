using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttributesController : AttributesController
{
    protected EnemyAttributesInfoAsset enemyAttributesInfoAsset;

    protected virtual void Start()
    {
        enemyAttributesInfoAsset = (EnemyAttributesInfoAsset)attributesInfoAsset;

        ResetAllAttributes();
    }
}
