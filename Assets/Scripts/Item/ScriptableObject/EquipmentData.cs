using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EquipmentData : ItemData
{
    [SerializeField]
    protected EquipmentType equipmentType;
    [SerializeField]
    protected EquipedValueType equipedValueType;
    [SerializeField]
    protected bool isEquiped;

    public EquipmentType EquipmentType { get { return equipmentType; } }
    public EquipedValueType EquipedValueType { get { return equipedValueType; } }
    public bool IsEquiped { get { return isEquiped; } private set { isEquiped = value; } }

    public void SetIsEquiped(bool b) { isEquiped = b; }
    public override EquipedValueType GetEquipedValueType() { return equipedValueType; }
}
