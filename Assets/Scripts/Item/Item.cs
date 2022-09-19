using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField]
    private ItemData itemData;
    public ItemData ItemData { get { return itemData; } }

    public Item(ItemData data)
    {
        itemData = data;
    }
}
