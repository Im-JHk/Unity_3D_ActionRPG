using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipmentUI : MonoBehaviour, IPointerClickHandler
{
    private PlayerEquipment playerEquipment;
    [SerializeField]
    private GameObject equipmentGO;
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
            equipmentGO.SetActive(true);
        }
    }

    public void RemoveItem()
    {
        equipmentImage.sprite = null;
        equipmentGO.SetActive(false);
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right && equipmentImage.sprite != null)
        {
            playerEquipment.DisequipItem(EquipmentType);
        }
    }
}
