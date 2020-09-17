using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipPoint : MonoBehaviour
{
    public ItemData eqiupedItem;
    public List<ItemSlotType> equipableItemTypes;
    private GameObject equipedItemInstance;

    public bool EquipItem(EquipableItem newItem)
    {
        if (!CheckIsItemEqiupable(newItem.slotType))
        {
            return false;
        }

        if(equipedItemInstance)
        {
            Destroy(equipedItemInstance);
        }

        eqiupedItem = newItem;

        GameObject prefab = Resources.Load<GameObject>("Items/"+eqiupedItem.prefabName);
        equipedItemInstance = Instantiate(prefab, this.transform);

        return true;
    }

    public bool CheckIsItemEqiupable(ItemSlotType itemSlotType)
    {
        return equipableItemTypes.Contains(itemSlotType);
    }

    public void UnEquipItem()
    {
        if (equipedItemInstance)
        {
            Destroy(equipedItemInstance);
        }

        eqiupedItem = null;
    }
}
