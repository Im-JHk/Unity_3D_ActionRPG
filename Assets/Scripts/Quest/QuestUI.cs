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
    private GameObject detailViewGO;
    [SerializeField]
    private QuestDetailViewUI detailViewUI;
    public bool IsQuestDetailOpen { get; private set; }
    #endregion

    private void Awake()
    {
        listSlotUI = new List<QuestSlotUI>();
        if (detailViewUI == null) detailViewUI = GetComponentInChildren<QuestDetailViewUI>();
        IsQuestListOpen = false;
        IsQuestDetailOpen = false;
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

    public void OpenQuestWindow(List<Quest> progessQuests, List<QuestData> possibleData)
    {
        IsQuestListOpen = true;

        questGO.SetActive(true);
        questListGO.SetActive(true);
        detailViewGO.SetActive(false);

        if (progessQuests != null)
        {
            for (int i = 0; i < progessQuests.Count; ++i)
            {
                AddSlot(progessQuests[i]);
            }
        }

        if (possibleData != null)
        {
            for (int i = 0; i < possibleData.Count; ++i)
            {
                AddSlot(possibleData[i].CreateQuest());
            }
        }
    }

    public void ClostQuestWindow()
    {
        IsQuestListOpen = false;

        questListGO.SetActive(true);
        detailViewGO.SetActive(true);
        questGO.SetActive(false);
    }

    public void OpenDetailView(Quest quest)
    {
        detailViewGO.SetActive(true);

        if (quest.Data.IsInProgressQuest) detailViewUI.SetButtonInterableIfInProgress(true);
        else detailViewUI.SetButtonInterableIfInProgress(false);
        detailViewUI.SetDetailViewUI(quest.Data.QuestName, quest.Data.QuestDescription, quest.GetInProgressTaskToString());
    }

    public void CloseDetailView()
    {
        detailViewGO.SetActive(false);
    }
}
