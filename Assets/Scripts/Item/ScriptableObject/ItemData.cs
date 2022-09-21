using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemData : ScriptableObject
{
    [SerializeField]
    protected string name;
    [SerializeField]
    protected string description;
    [SerializeField]
    protected ItemType itemType;
    [SerializeField]
    protected Sprite image;
    [SerializeField]
    protected GameObject prefab;

    public string Name { get { return name; } }
    public string Description { get { return description; } }
    public ItemType ItemType { get { return itemType; } }
    public Sprite Image { get { return image; } }
    public GameObject Prefab { get { return prefab; } }

    public abstract Item CreateItem();
    public abstract string GetItemValueToString();
}
