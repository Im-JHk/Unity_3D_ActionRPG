using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipmentUI : MonoBehaviour, IPointerClickHandler
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
}
