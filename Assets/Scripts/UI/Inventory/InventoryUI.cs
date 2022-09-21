using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    private Inventory inventory = null;
    [SerializeField]
    private Transform contentSpace = null;
    [SerializeField]
    private GameObject slotPrefab = null;
    [SerializeField]
    private GameObject popupUI = null;
    [SerializeField]
    private ItemTooltip itemTooltip = null;
    [SerializeField]
    private List<SlotUI> listSlotUI;

    [SerializeField]
    private int maxSlotColumn = 5;
    [SerializeField]
    private int maxSlotRow = 7;
    [SerializeField]
    private float slotMargin = 5f;
    [SerializeField]
    private float slotPadding = 40f;
    [SerializeField]
    private float slotSize = 100f;

    public SlotUI DraggingSlot { get; private set; }
    public bool IsSlotDragging { get; set; }
    public bool IsDropIn { get; set; }
    public bool IsSlotTooltipOn { get; set; }

    public void Initialize(Inventory inventory)
    {
        this.inventory = inventory;
        DraggingSlot = null;
        IsSlotDragging = false;
        IsSlotTooltipOn = false;
        CreateSlots();
    }

    public void CreateSlots()
    {
        slotPrefab.GetComponent<RectTransform>().sizeDelta = new Vector2(slotSize, slotSize); ;

        Vector2 beginPos = new Vector2(slotPadding, -slotPadding);
        Vector2 curPos = beginPos;

        listSlotUI = new List<SlotUI>();

        for (int i = 0; i < maxSlotRow; ++i)
        {
            for (int j = 0; j < maxSlotColumn; ++j)
            {
                int index = (maxSlotColumn * i) + j;

                GameObject newSlot = Instantiate(slotPrefab);
                RectTransform rectTransform = newSlot.GetComponent<RectTransform>();
                rectTransform.SetParent(contentSpace);
                rectTransform.pivot = new Vector2(0f, 1f);
                rectTransform.localScale = new Vector3(1f, 1f, 1f);
                rectTransform.anchoredPosition = curPos;
                rectTransform.gameObject.name = $"Slot[{index}]";
                rectTransform.gameObject.SetActive(true);

                SlotUI slotUI = newSlot.GetComponent<SlotUI>();
                slotUI.SetIndex(index);
                slotUI.SetInventoryRefference(inventory, this);
                listSlotUI.Add(slotUI);

                curPos.x += (slotMargin + slotSize);
            }
            curPos.x = beginPos.x;
            curPos.y -= (slotMargin + slotSize);
        }
    }

    public void SetSlotItem(Sprite sprite, int index)
    {
        listSlotUI[index].SetItem(sprite);
    }

    public void RemoveItem(int index)
    {
        listSlotUI[index].RemoveItem();
    }

    public void SetDragSlot(SlotUI slot)
    {
        if (DraggingSlot == null) DraggingSlot = slot;
    }

    public void SwapSlot(SlotUI other)
    {
        inventory.SwapData(DraggingSlot.Index, other.Index);
        DraggingSlot = null;
    }

    #region Tooltip
    public void ShowTooltip(int index, Vector3 pos)
    {
        itemTooltip.ShowTooltip(inventory.GetItemData(index), pos);
    }

    public void HideTooltip()
    {
        itemTooltip.HideTooltip();
    }
    #endregion
}
