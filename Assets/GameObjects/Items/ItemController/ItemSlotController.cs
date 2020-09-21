using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlotController : MonoBehaviour
{
    public List<EquipPoint> slots;

    public bool InsertItemToSlot(int slotIndex, EquipableItem newItem)
    {
        if(slots.Count < slotIndex || slotIndex < 0)
        {
            return false;
        }

        return slots[slotIndex].EquipItem(newItem);
    }

    public bool RemoveItemFromSlot(int slotIndex)
    {
        if (slots.Count < slotIndex || slotIndex < 0)
        {
            return false;
        }

        slots[slotIndex].UnEquipItem();

        return true;
    }
}
