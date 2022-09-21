using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour, 
    IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IPointerUpHandler, 
    IBeginDragHandler, IDragHandler, IDropHandler, IEndDragHandler
{
    [SerializeField]
    private Inventory inventory;
    [SerializeField]
    private InventoryUI inventoryUI;
    [SerializeField]
    private GameObject slotGO;
    [SerializeField]
    private GameObject itemImageGO;
    [SerializeField]
    private GameObject overImageGO;
    [SerializeField]
    private GameObject quantityGO;

    [SerializeField]
    private Image itemImage;
    [SerializeField]
    private Image overImage;
    [SerializeField]
    private Text quantityText;

    private RectTransform contentSpaceRT;
    private GraphicRaycaster gRay;
    private List<RaycastResult> listRayResults = new List<RaycastResult>();

    private Vector3 beginDragPosition;

    public int Index { get; private set; }
    public Image ItemImage { get { return itemImage; } }

    public void SetIndex(int index) => Index = index;

    public void Awake()
    {
        gRay = GetComponentInParent<GraphicRaycaster>();
        contentSpaceRT = transform.parent.GetComponent<RectTransform>();
    }

    public void HideComponents()
    {
        itemImageGO.SetActive(false);
        overImageGO.SetActive(false);
        quantityGO.SetActive(false);
    }

    public void SetInventoryRefference(Inventory inventory, InventoryUI inventoryUI)
    {
        this.inventory = inventory;
        this.inventoryUI = inventoryUI;
    }

    public void SetItem(Sprite sprite)
    {
        if (sprite == null) RemoveItem();
        else
        {
            itemImage.sprite = sprite;
            itemImageGO.SetActive(true);
        }
    }

    public void SetQuantity(int qty)
    {
        quantityText.text = qty.ToString();
    }

    public void RemoveItem()
    {
        itemImage.sprite = null;
        quantityText.text = "";
        itemImageGO.SetActive(false);
        overImageGO.SetActive(false);
        quantityGO.SetActive(false);
    }

    #region Mouse Event
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(itemImage.sprite != null && !inventoryUI.IsSlotDragging)
        {
            inventoryUI.IsSlotTooltipOn = true;
            inventoryUI.ShowTooltip(Index, transform.position);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (inventoryUI.IsSlotTooltipOn)
        {
            inventoryUI.HideTooltip();
            inventoryUI.IsSlotTooltipOn = false;
        }
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            if (inventory.IsEquipable(this.Index))
            {
                Item item = inventory.GetItem(this.Index);
                inventory.ClearItem(this.Index);
                UIManager.Instance.EquipItem(item);
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (inventoryUI.IsSlotDragging)
        {
            print("point up");
            bool isInArea = false;
            listRayResults.Clear();
            gRay.Raycast(eventData, listRayResults);
            for (int i = 0; i < listRayResults.Count; ++i)
            {
                if (listRayResults[i].gameObject.CompareTag("Inventory"))
                {
                    isInArea = true;
                    break;
                }
            }

            if (!isInArea)
            {
                print("remove");
                inventory.ClearItem(Index);
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (itemImage.sprite != null)
        {
            print("begin drag: " + this.gameObject);
            beginDragPosition = itemImage.transform.position;
            inventoryUI.SetDragSlot(this);
            inventoryUI.IsSlotDragging = true;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (inventoryUI.IsSlotDragging)
        {
            itemImage.transform.position = eventData.position;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (inventoryUI.IsSlotDragging)
        {
            print("drop drag: " + this);
            if (inventoryUI.DraggingSlot == this) return;
            else inventoryUI.SwapSlot(this);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (inventoryUI.IsSlotDragging)
        {
            print("end drag: " + this.gameObject);
            itemImage.transform.position = beginDragPosition;
            inventoryUI.IsSlotDragging = false;
        }
    }
    #endregion
}
