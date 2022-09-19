using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private GridLayoutGroup grid = null;
    [SerializeField]
    private List<Slot> listSlots = new List<Slot>();
    [SerializeField]
    private GameObject slotPrefab = null;
    [SerializeField]
    private GameObject popupInfo = null;
    [SerializeField]
    private InventoryUI inventoryUI = null;

    private int maxSlotColumn = 5;
    private int maxSlotRow = 7;
    private int maxSlot;
    private Item[] items;

    private void Awake()
    {
        inventoryUI = GetComponent<InventoryUI>();
        maxSlot = maxSlotColumn * maxSlotRow;
        items = new Item[maxSlot];
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public int FindEmptySlot()
    {
        for(int i = 0; i < maxSlot; ++i)
            if (items[i] == null) return i;
        return -1;
    }

    public void UpdateSlot(int index)
    {
        Item item = items[index];
        if(items[index] == null)
        {
            print("deactive slot");
            inventoryUI.RemoveItem(index);
        }
        else
        {
            print("active slot");
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
            print("No CDATA");
            int index = FindEmptySlot();
            if(index == -1)
            {
                print("Inventory is Full");
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
}
