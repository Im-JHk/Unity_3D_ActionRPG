using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingletonMono<UIManager>
{
    public Action UpdateStatus { get; set; }
    public Action PointUp { get; set; }

    #region Status, Inventory
    public GameObject StatusInventoryGO;
    public GameObject StatusGO;
    public GameObject InventoryGO;

    [SerializeField]
    private PlayerEquipment playerEquipmentRef;
    [SerializeField]
    private Inventory inventoryRef;

    public Animator[] TextAnim;

    public Button SwitchStatusButton;
    public Button SwitchInventoryButton;
    private int SwitchStatusButtonOriginSibling;
    private int SwitchInventoryButtonOriginSibling;

    // Equipment
    

    // Status
    public Text levelText;
    public Text hpText;
    public Text mpText;
    public Text atkText;
    public Text defText;
    public Text remainPointText;

    public Text expText;
    public Slider expSlider;

    public Button[] plusHpPointButton;
    public Button[] plusMpPointButton;
    public Button[] plusAtkPointButton;
    public Button[] plusDefPointButton;

    public Text plusHpPointText;
    public Text plusMpPointText;
    public Text plusAtkPointText;
    public Text plusDefPointText;

    public Text plusHpValueText;
    public Text plusMpValueText;
    public Text plusAtkValueText;
    public Text plusDefValueText;

    public readonly int HashUpTrigger = Animator.StringToHash("UpTrigger");
    // Inventory
    

    #endregion

    private void Awake()
    {
        //for(int i = 0; i < Enum.GetValues(typeof(EquipmentType)).Length; ++i)
        //{
        //    dicEquipmentUI.Add((EquipmentType)i, )
        //}
    }

    public bool SetActiveSwitchingStatusInventory()
    {
        if (StatusInventoryGO.activeSelf)
        {
            StatusInventoryGO.SetActive(false);
            return false;
        }
        else
        {
            StatusInventoryGO.SetActive(true);
            StatusGO.SetActive(true);
            InventoryGO.SetActive(false);
            return true;
        }
    }

    public void SetDeactiveStatusInventory()
    {
        StatusInventoryGO.SetActive(false);
    }

    public void OnClickSwitchButton(int index)
    {
        switch (index)
        {
            case 1:
                StatusGO.SetActive(true);
                InventoryGO.SetActive(false);
                SwitchInventoryButton.transform.SetAsFirstSibling();
                break;
            case 2:
                StatusGO.SetActive(false);
                InventoryGO.SetActive(true);
                SwitchStatusButton.transform.SetAsFirstSibling();
                break;
        }
    }

    public void EquipItem(Item item)
    {
        playerEquipmentRef.EquipItem(item);
    }

    public void DisequipItem(Item item)
    { 
        print(inventoryRef);
        inventoryRef.AddItem(item.ItemData);
    }
}
