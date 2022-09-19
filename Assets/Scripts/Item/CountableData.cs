using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountableData : ItemData
{
    [SerializeField]
    protected int quantity;
    public int Quantity { get { return quantity; } }
}
