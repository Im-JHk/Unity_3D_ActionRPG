using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Equipment : Item
{
    [SerializeField]
    protected EquipmentData equipmentData;

    public EquipmentData EquipmentData { get { return equipmentData; } protected set { equipmentData = value; } }
    public Equipment(EquipmentData data) : base(data) 
    {
        equipmentData = data;
    }
}
