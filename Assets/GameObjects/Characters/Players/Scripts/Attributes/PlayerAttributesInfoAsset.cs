using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerAttributesInfoAsset", menuName = "ProjectARPG/Player Attributes Info Asset")]
public class PlayerAttributesInfoAsset : AttributesInfoAsset
{
    [Header("Specific Attributes")]
    [SerializeField]
    [Range(0, 100)]
    float rotateSpeed = 1f;
    [SerializeField]
    [Range(0, 100)]
    float jumpSpeed = 1;

    public RangedFloatValue RotateSpeed { get; private set; }
    public RangedFloatValue JumpSpeed { get; private set; }

    public override void OnAfterDeserialize()
    {
        base.OnAfterDeserialize();

        RotateSpeed = new RangedFloatValue(rotateSpeed, 0, 100);
        JumpSpeed = new RangedFloatValue(jumpSpeed, 0, 100);
    }

    public PlayerAttributesInfoAsset()
    {
        EntityType = EntityType.Player;
        targetType = TargetType.Enemy;
    }
}