using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerEquipment : MonoBehaviour
{
    [SerializeField]
    private PlayerStat playerStat;
    [SerializeField]
    private EquipmentUI[] equipmentUIs;
    [SerializeField]
    private Dictionary<EquipmentType, EquipmentUI> dicEquipmentUI;
    [SerializeField]
    private Dictionary<EquipmentType, Item> dicEquipment;

    private void Awake()
    {
        playerStat = GetComponent<PlayerStat>();

        //equipmentUIs = new EquipmentUI[Enum.GetValues(typeof(EquipmentType)).Length];
        dicEquipmentUI = new Dictionary<EquipmentType, EquipmentUI>();
        dicEquipment = new Dictionary<EquipmentType, Item>();
        for(int i = 0; i < Enum.GetValues(typeof(EquipmentType)).Length; ++i)
        {
            print(equipmentUIs[i]);
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
            if(dicEquipmentUI[eqData.EquipmentType].EquipmentImage.sprite != null)
            {
                var prevItem = dicEquipment[eqData.EquipmentType];
                SendItemToInventory(prevItem);
            }
            dicEquipment[eqData.EquipmentType] = item;
            dicEquipmentUI[eqData.EquipmentType].SetItem(eqData.Image);

            ReCalculateStat();
        }
    }

    public void ReCalculateStat()
    {
        int atk, def;
        SumUpAllEquipedValue(out atk, out def);
        playerStat.SetEquipedStats(atk, def);
        playerStat.UpdateStatusUI();
    }

    public void SumUpAllEquipedValue(out int atk, out int def)
    {
        atk = 0;
        def = 0;
        for(int i = 0; i < Enum.GetValues(typeof(EquipmentType)).Length; ++i)
        {
            EquipmentType key = (EquipmentType)i;
            if(dicEquipment[key] != null)
            {
                if (dicEquipment[key].ItemData.GetEquipedValueType() == EquipedValueType.Atk) atk += dicEquipment[key].ItemData.GetItemValue();
                else if (dicEquipment[key].ItemData.GetEquipedValueType() == EquipedValueType.Def) def += dicEquipment[key].ItemData.GetItemValue();
            }
        }
    }

    public void DisequipItem(EquipmentType type)
    {
        SendItemToInventory(dicEquipment[type]);
        dicEquipment[type] = null;
        dicEquipmentUI[type].RemoveItem();

        ReCalculateStat();
    }

    public void SendItemToInventory(Item item)
    {
        UIManager.Instance.DisequipItem(item);
    }
}
