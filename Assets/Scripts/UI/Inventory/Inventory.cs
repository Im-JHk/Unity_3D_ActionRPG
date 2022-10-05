using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private InventoryUI inventoryUI = null;

    private int maxSlotColumn = 5;
    private int maxSlotRow = 7;
    private int maxSlotSize;
    private Item[] items;

    private int gold;

    private void Awake()
    {
        inventoryUI = GetComponent<InventoryUI>();
        maxSlotSize = maxSlotColumn * maxSlotRow;
        items = new Item[maxSlotSize];
        inventoryUI.Initialize(this);
        UpdateAllSlots();
    }

    public void UpdateAllSlots()
    {
        for (int i = 0; i < maxSlotSize; ++i) UpdateSlot(i);
    }

    public int FindEmptySlot()
    {
        for(int i = 0; i < maxSlotSize; ++i)
            if (items[i] == null) return i;
        return -1;
    }

    public void UpdateSlot(int index)
    {
        Item item = items[index];
        if(items[index] == null)
        {
            inventoryUI.RemoveItem(index);
        }
        else
        {
            inventoryUI.SetSlotItem(item.ItemData.Image, index);
        }
    }

    public int AddItem(ItemData data, int quantity = 1)
    {
        if(data is CountableData cData)
        {
            print("CDATA");
        }
        else
        {
            int index = FindEmptySlot();
            if(index == -1)
            {
                Debug.Log("Inventory is Full");
            }
            else
            {
                items[index] = data.CreateItem();
                UpdateSlot(index);
            }
            return index;
        }
        return 0;
    }

    public void AddGold(int gold)
    {
        this.gold += gold;
    }

    public void ClearItem(int index)
    {
        items[index] = null;
        UpdateSlot(index);
    }

    public Item GetItem(int index)
    {
        return items[index];
    }

    public ItemData GetItemData(int index)
    {
        return items[index].ItemData;
    }

    public bool IsEquipable(int index)
    {
        if (items[index] is Equipment) return true;
        else return false;
    }

    public void SwapData(int leftIndex, int rightIndex)
    {
        var temp = items[leftIndex];
        items[leftIndex] = items[rightIndex];
        items[rightIndex] = temp;

        UpdateSlot(leftIndex);
        UpdateSlot(rightIndex);
    }
}
