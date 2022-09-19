using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    private Inventory inventory = null;
    [SerializeField]
    private SlotUI[] slots;

    public void RemoveItem(int index)
    {
        slots[index].RemoveItem();
    }
}
