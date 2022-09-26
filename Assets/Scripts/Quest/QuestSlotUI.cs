using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class QuestSlotUI : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private Quest quest;
    [SerializeField]
    private Image background;
    [SerializeField]
    private Text questName;
    [SerializeField]
    private Text questTask;

    private int index;
    private bool isDetailOpen = false;

    public void SetIndex(int index) => this.index = index;
    public void SetQuest(Quest quest) => this.quest = quest;
    public void SetInitialize(int index)
    {
        this.index = index;
        this.isDetailOpen = false;
    }

    public void SetQuestSlot()
    {
        if (quest.IsQuestComplete()) background.color = Color.green;
        else background.color = Color.white;

        Color color = background.color;
        if (quest.IsProgress) color.a = 1f;
        else color.a = 0.2f;
        background.color = color;

        questName.text = quest.Data.QuestName;
        questTask.text = quest.GetInProgressTaskToString();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (isDetailOpen)
            {
                UIManager.Instance.CloseDetailView();
                isDetailOpen = false;
            }
            else
            {
                UIManager.Instance.OpenDetailView(quest);
                isDetailOpen = true;
            }
        }
    }
}
