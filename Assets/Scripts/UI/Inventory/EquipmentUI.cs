using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipmentUI : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private PlayerEquipment playerEquipment;
    [SerializeField]
    private GameObject equipmentGO;
    [SerializeField]
    private GameObject equipmentImageGO;
    [SerializeField]
    private Image equipmentImage;

    public Image EquipmentImage { get { return equipmentImage; } }
    public EquipmentType EquipmentType { get; private set; }

    public void SetEquipReference(PlayerEquipment peq) => playerEquipment = peq;
    public void SetEquipmentType(EquipmentType type) => EquipmentType = type;

    public void SetItem(Sprite sprite)
    {
        if (sprite == null) RemoveItem();
        else
        {
            equipmentImage.sprite = sprite;
            equipmentImageGO.SetActive(true);
        }
    }

    public void RemoveItem()
    {
        equipmentImage.sprite = null;
        equipmentImageGO.SetActive(false);
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right && equipmentImage.sprite != null)
        {
            playerEquipment.DisequipItem(EquipmentType);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (equipmentImage.sprite != null && !playerEquipment.IsTooltipOn)
        {
            playerEquipment.IsTooltipOn = true;
            UIManager.Instance.ShowTooltip(playerEquipment.DicEquipment[EquipmentType].ItemData, GetComponent<RectTransform>().position);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (playerEquipment.IsTooltipOn)
        {
            UIManager.Instance.HideTooltip();
            playerEquipment.IsTooltipOn = false;
        }
    }
}
