using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StatusEffectInfoAsset", menuName = "ProjectARPG/Status Effects/Status Effect Info Asset")]
public class StatusEffectInfoAsset : ScriptableObject
{
    [Space]
    public Dictionary<DamageStatusType, GameObject> statusEffectInfoDict;
}