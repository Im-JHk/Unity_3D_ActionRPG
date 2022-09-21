using UnityEngine;
using UnityEngine.UI;

public class ItemTooltip : MonoBehaviour
{
    [SerializeField]
    private Text itemName;
    [SerializeField]
    private Text itemDescription;
    [SerializeField]
    private Text itemValue;
    [SerializeField]
    private Text howToUse;

    public void ShowTooltip(ItemData data, Vector3 pos)
    {
        gameObject.SetActive(true);
        pos += new Vector3(GetComponent<RectTransform>().rect.width * 0.5f, -GetComponent<RectTransform>().rect.height * 0.5f, 0);
        gameObject.transform.position = pos;

        itemName.text = data.Name;
        itemDescription.text = data.Description;
        itemValue.text = data.GetItemValueToString();

        switch (data.ItemType)
        {
            case ItemType.Normal:
                howToUse.text = "사용 불가";
                break;
            case ItemType.Equipable:
                howToUse.text = "장착(우클릭)";
                break;
            case ItemType.Consumable:
                howToUse.text = "사용(우클릭)";
                break;
        }
    }

    public void HideTooltip()
    {
        gameObject.SetActive(false);
    }
}
