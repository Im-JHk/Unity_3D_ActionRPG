using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour
{
    [SerializeField]
    private GameObject slot;
    [SerializeField]
    private GameObject item;
    [SerializeField]
    private GameObject quantity;
    [SerializeField]
    private Text quantityText;

    public void RemoveItem()
    {
        // item √ ±‚»≠
        quantityText.text = "0";
        item.SetActive(false);
        quantity.SetActive(false);
    }
}
