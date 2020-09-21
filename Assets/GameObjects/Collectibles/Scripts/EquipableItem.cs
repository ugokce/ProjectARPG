using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EquipableItem : ItemData
{
    public ItemSlotType slotType = ItemSlotType.None;

    public List<Stat> getRequirements()
    {
        return requirements;
    }
}
