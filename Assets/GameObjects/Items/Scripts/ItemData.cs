using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemSlotType
{
    LeftHand,
    RightHand,
    BothHand,
    Head,
    Body,
    Foot,
    None
}

public abstract class ItemData : ScriptableObject
{
    public string prefabName;
    public string description;
    public List<Stat> requirements;
}
