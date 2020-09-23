using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerAttributesInfoAsset", menuName = "ProjectARPG/Player Attributes Info Asset")]
public class PlayerAttributesInfoAsset : AttributesInfoAsset
{
    [Header("Specific Attributes")]
    [Range(0, 100)]
    public float rotateSpeed = 1f;
    [Range(0, 100)]
    public float jumpSpeed = 1f;
}
