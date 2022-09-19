using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EquipmentData : ItemData
{
    [SerializeField]
    protected bool isEquiped;

    public bool IsEquiped { get { return isEquiped; } }
}
