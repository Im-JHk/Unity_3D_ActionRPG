using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingletonMono<UIManager>
{
    public Action UpdateStatus { get; set; }
    public Action PointUp { get; set; }

    #region Dialogue
    public GameObject DialogueGO;
    public UnityEvent OnDialogue;
    #endregion

    #region ButtonList
    [SerializeField]
    private ButtonListUI buttonListUI;
    #endregion

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

    // Equipment


    // Status
    private PlayerStat playerStat;

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

    #region Quest
    [SerializeField]
    private QuestUI questUI;
    private QuestSlotUI openDetailSlot = null;
    #endregion

    private void Awake()
    {
        if (questUI == null) questUI = FindObjectOfType<QuestUI>();
    }

    public void OpenOrCloseButtonList()
    {
        if (buttonListUI.IsOpen) buttonListUI.OnClickCloseList();
        else buttonListUI.OnClickOpenList();
    }

    #region Inventory Method
    public void OpenInventoryUI()
    {
        if (SetActiveSwitchingStatusInventory()) playerStat.UpdateStatusUI();
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
    #endregion

    public void StartDialogue()
    {
        DialogueGO.SetActive(true);
        OnDialogue.Invoke();
    }

    #region Quest Method
    public void OpenOrCloseQuestList()
    {
        if (questUI.IsQuestListOpen)
        {
            questUI.ClostQuestWindow();
        }
        else
        {
            questUI.OpenQuestWindow(QuestManager.Instance.ListProgressQuest, QuestManager.Instance.ListPossibleQuest);
        }
    }

    public void OpenDetailView(Quest quest)
    {
        questUI.OpenDetailView(quest);
    }

    public void CloseDetailView()
    {
        questUI.CloseDetailView();
    }
    #endregion
}
