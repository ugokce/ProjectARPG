using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributesController : AttributesController
{
    protected PlayerAttributesInfoAsset playerAttributesInfoAsset;

    public float JumpSpeed { get; set; }
    public float RotateSpeed { get; set; }

    protected virtual void Start()
    {
        playerAttributesInfoAsset = (PlayerAttributesInfoAsset)attributesInfoAsset;

        ResetAllAttributes();
    }

    public override void ResetAllAttributes()
    {
        base.ResetAllAttributes();

        JumpSpeed = playerAttributesInfoAsset.rotateSpeed;
        RotateSpeed = playerAttributesInfoAsset.rotateSpeed;
    }
}
