using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestUI : MonoBehaviour
{
    [SerializeField]
    private GameObject questGO;

    #region QuestList
    [SerializeField]
    private GameObject questListGO;
    [SerializeField]
    private GameObject slotPrefab;
    [SerializeField]
    private Transform contentSpace;
    private List<QuestSlotUI> listSlotUI;
    public bool IsQuestListOpen { get; private set; }
    #endregion

    #region DetailView
    [SerializeField]
    private Quest openQuest = null;
    [SerializeField]
    private int openQuestIndex;
    [SerializeField]
    private GameObject detailViewGO;
    [SerializeField]
    private QuestDetailViewUI detailViewUI;
    public bool IsQuestDetailOpen { get; private set; }
    #endregion

    public GameObject QuestGO { get { return questGO; } }

    private void Awake()
    {
        InitializeQuestUI();
    }

    public void InitializeQuestUI()
    {
        if (listSlotUI == null) listSlotUI = new List<QuestSlotUI>();
        if (detailViewUI == null) detailViewUI = GetComponentInChildren<QuestDetailViewUI>();
        IsQuestListOpen = false;
        IsQuestDetailOpen = false;

        for (int i = 0; i < QuestManager.Instance.ListYetProgressQuest.Count; ++i)
        {
            AddSlot(QuestManager.Instance.ListYetProgressQuest[i]);
        }
    }

    public void AddSlot(Quest quest)
    {
        int index = listSlotUI.Count;
        GameObject newSlot = Instantiate(slotPrefab);
        RectTransform rectTransform = newSlot.GetComponent<RectTransform>();
        rectTransform.SetParent(contentSpace);
        rectTransform.gameObject.name = $"Slot[{index}]";
        rectTransform.gameObject.SetActive(true);

        QuestSlotUI slotUI = newSlot.GetComponent<QuestSlotUI>();
        slotUI.SetIndex(index);
        slotUI.SetQuest(quest);
        listSlotUI.Add(slotUI);
    }

    public void OpenQuestWindow()
    {
        IsQuestListOpen = true;

        questGO.SetActive(true);
        questListGO.SetActive(true);
        detailViewGO.SetActive(false);

        for (int i = 0; i < listSlotUI.Count; ++i)
        {
            listSlotUI[i].SetQuestSlotUI();
        }
    }

    public void ClostQuestWindow()
    {
        IsQuestListOpen = false;

        questListGO.SetActive(true);
        detailViewGO.SetActive(true);
        questGO.SetActive(false);
    }

    public void OpenOrCloseDetailView(Quest quest, int index)
    {
        if (openQuest != null && openQuest == quest)
        {
            detailViewGO.SetActive(false);
            openQuest = null;
            return;
        }

        openQuest = quest;
        openQuestIndex = index;
        detailViewGO.SetActive(true);

        if (quest != null && quest.IsProgress) detailViewUI.SetButtonInterableIfInProgress(true);
        else detailViewUI.SetButtonInterableIfInProgress(false);

        detailViewUI.SetDetailViewUI(quest.Data.QuestName, quest.Data.QuestDescription, quest.GetInProgressTaskToString());
    }

    public void AcceptQuest()
    {
        if (openQuest == null) return;
        QuestManager.Instance.AcceptQuest(openQuest);
        listSlotUI[openQuestIndex].SetQuestSlotUI();
        detailViewUI.SetButtonInterableIfInProgress(true);
    }

    public void RefuseQuest()
    {
        if (openQuest == null) return;
        QuestManager.Instance.RefuseQuest(openQuest);
        listSlotUI[openQuestIndex].SetQuestSlotUI();
        detailViewUI.SetButtonInterableIfInProgress(true);
    }
}
