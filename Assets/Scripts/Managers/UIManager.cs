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

    private ItemTooltip itemTooltip;

    #region Dialogue
    public GameObject InteractionGO;
    public GameObject DialogueGO;
    public Dialogue Dialogue;

    public DialogueDataSO readyDialogueData = null;
    public Transform readyDialogueTarget = null;
    #endregion

    #region HUD
    [SerializeField]
    private ButtonListUI buttonListUI;
    [SerializeField]
    private QuestDisplay questDisplay;
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
    [SerializeField]
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
    #endregion

    public void SetItemTooltipRef(ItemTooltip itemTooltip) => this.itemTooltip = itemTooltip;

    private void Awake()
    {
        if (questUI == null) questUI = FindObjectOfType<QuestUI>();
        if (questDisplay == null) questDisplay = FindObjectOfType<QuestDisplay>();
    }

    #region HUD

    public void OpenOrCloseQuestDisplay()
    {
        if (questDisplay.IsOpen) questDisplay.OnClickCloseList();
        else questDisplay.OnClickOpenList();
    }

    public void OpenOrCloseButtonList()
    {
        if (buttonListUI.IsOpen) buttonListUI.OnClickCloseList();
        else buttonListUI.OnClickOpenList();
    }

    public void SetActiveInteractionButton(bool flag)
    {
        if (flag) InteractionGO.SetActive(true);
        else InteractionGO.SetActive(false);
    }
    #endregion

    #region Dialogue
    public void SetReadyDialogue(DialogueDataSO dialogueData, Transform target)
    {
        readyDialogueData = dialogueData;
        readyDialogueTarget = target;
    }

    public void StartDialogue()
    {
        if(readyDialogueData != null && readyDialogueTarget != null)
        {
            DialogueGO.SetActive(true);
            Dialogue.SetDialogue(readyDialogueData);
            Dialogue.StartDialogue();
        }
    }
    #endregion

    #region Status Inventory Method
    public void ShowTooltip(ItemData itemData, Vector3 pos)
    {
        itemTooltip.ShowTooltip(itemData, pos);
    }

    public void HideTooltip()
    {
        itemTooltip.HideTooltip();
    }

    public void OpenOrCloseStatusUI()
    {
        if (StatusInventoryGO.activeSelf)
        {
            StatusInventoryGO.SetActive(false);
        }
        else
        {
            StatusInventoryGO.SetActive(true);
            OnClickSwitchButton(1);
            playerStat.UpdateStatusUI();
        }
    }

    public void OpenOrCloseInventoryUI()
    {
        if (StatusInventoryGO.activeSelf)
        {
            StatusInventoryGO.SetActive(false);
        }
        else
        {
            StatusInventoryGO.SetActive(true);
            OnClickSwitchButton(2);
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

    #region Quest Method
    public void InitializeQuestUI()
    {
        questUI.InitializeQuestUI();
    }

    public void OpenOrCloseQuestList()
    {
        if (questUI.IsQuestListOpen)
        {
            questUI.ClostQuestWindow();
        }
        else
        {
            questUI.OpenQuestWindow();
        }
    }

    public void OpenOrCloseDetailView(Quest quest, int index)
    {
        questUI.OpenOrCloseDetailView(quest, index);
    }

    public void GetReward(QuestReward reward)
    {
        for(int i = 0; i < reward.Items.Length; ++i)
        {
            inventoryRef.AddItem(reward.Items[i]);
        }
        inventoryRef.AddGold(reward.Gold);
        playerStat.GetExp(reward.Experience);
        
    }
    #endregion

    public void SetDeactiveUIs()
    {
        StatusInventoryGO.SetActive(false);
        questUI.QuestGO.SetActive(false);
    }
}
