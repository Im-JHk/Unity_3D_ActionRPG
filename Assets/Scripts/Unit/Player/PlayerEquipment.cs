using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerEquipment : MonoBehaviour
{
    [SerializeField]
    private EquipmentUI[] equipmentUIs;
    [SerializeField]
    private Dictionary<EquipmentType, EquipmentUI> dicEquipmentUI;
    [SerializeField]
    private Dictionary<EquipmentType, Item> dicEquipment;

    private void Awake()
    {
        equipmentUIs = new EquipmentUI[Enum.GetValues(typeof(EquipmentType)).Length];
        dicEquipmentUI = new Dictionary<EquipmentType, EquipmentUI>();
        dicEquipment = new Dictionary<EquipmentType, Item>();
        for(int i = 0; i < Enum.GetValues(typeof(EquipmentType)).Length; ++i)
        {
            EquipmentType type = (EquipmentType)i;
            dicEquipment.Add(type, null);
            dicEquipmentUI.Add(type, equipmentUIs[i]);
            dicEquipmentUI[type].SetEquipmentType(type);
        }
    }

    public void EquipItem(Item item)
    {
        if(item.ItemData is EquipmentData eqData)
        {
            if(dicEquipmentUI[eqData.EquipmentType].EquipmentImage != null)
            {
                var prevItem = dicEquipment[eqData.EquipmentType];
                SendItemToInventory(prevItem);
            }
            dicEquipment[eqData.EquipmentType] = item;
            dicEquipmentUI[eqData.EquipmentType].SetItem(eqData.Image);
        }
    }

    public void DisequipItem(EquipmentType type)
    {
        SendItemToInventory(dicEquipment[type]);
    }

    public void SendItemToInventory(Item item)
    {
        UIManager.Instance.DisequipItem(item);
    }
}
