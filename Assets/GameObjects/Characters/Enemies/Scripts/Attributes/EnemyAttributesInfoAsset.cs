using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyAttributesInfoAsset", menuName = "ProjectARPG/Enemy Attributes Info Asset")]
public class EnemyAttributesInfoAsset : AttributesInfoAsset
{
    public EnemyAttributesInfoAsset()
    {
        EntityType = EntityType.Enemy;
        targetType = TargetType.Player;
    }
}
