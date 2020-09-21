using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot : MonoBehaviour
{
    public Item insertedItem;
    public ItemSlotType ItemSlotType = ItemSlotType.None;

    public Item InsertItem(Item newItem)
    {
        Item previousItem = insertedItem;
        insertedItem = newItem;

        return previousItem;
    }
}
