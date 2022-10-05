using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : SingletonMono<QuestManager>
{
    [SerializeField]
    private Player player;
    [SerializeField]
    private List<QuestData> listQuestData;
    [SerializeField]
    private List<Quest> listYetProgressQuest;
    [SerializeField]
    private List<Quest> listProgressQuest;
    [SerializeField]
    private List<int> listCompleteQuestID;

    public List<Quest> ListYetProgressQuest { get { return listYetProgressQuest; } }
    public List<Quest> ListProgressQuest { get { return listProgressQuest; } }

    private void Awake()
    {
        if (player == null) player = FindObjectOfType<Player>();
        listYetProgressQuest = new List<Quest>();
        listProgressQuest = new List<Quest>();
        listCompleteQuestID = new List<int>();

        for (int i = 0; i < listQuestData.Count; ++i)
        {
            listYetProgressQuest.Add(listQuestData[i].CreateQuest());
        }
    }

    public void UpdateProgressQuestList(int level)
    {
        for (int i = listYetProgressQuest.Count - 1; i >= 0; --i)
        {
            if (listYetProgressQuest[i].Data.QuestCondition.IsCanProgressLevel(level) && 
                listYetProgressQuest[i].Data.QuestCondition.IsPrevQuestClear(listCompleteQuestID))
            {
                print("possible");
                //listProgressQuest.Add(listQuestData[i]);
            }
        }
    }

    public int GetPossibleIndex(int questID)
    {
        for (int i = 0; i < listYetProgressQuest.Count; ++i)
        {
            if (listYetProgressQuest[i].Data.QuestID == questID) return i;
        }
        return -1;
    }

    public void AcceptQuest(Quest quest)
    {
        quest.SetIsProgress(true);
        int index = listYetProgressQuest.IndexOf(quest);
        listProgressQuest.Add(listYetProgressQuest[index]);
        listYetProgressQuest.RemoveAt(index);
    }

    public void RefuseQuest(Quest quest)
    {
        quest.SetIsProgress(false);
        int index = listProgressQuest.IndexOf(quest);
        listYetProgressQuest.Add(listProgressQuest[index]);
        listProgressQuest.RemoveAt(index);
    }

    public void NotifyClearQuest(Quest quest)
    {
        listCompleteQuestID.Add(quest.Data.QuestID);

        int index = listProgressQuest.IndexOf(quest);
        UIManager.Instance.GetReward(quest.Data.QuestReward);
        listProgressQuest.RemoveAt(index);
        //for (int i = 0; i < listQuestData.Count; ++i)
        //{
        //    listCompleteQuestID.Add(listQuestData[i].QuestID);
        //}
        //for(int i = 0; i < listProgressQuest.Count; ++i)
        //{
        //    if (listProgressQuest[i].Data.QuestID == questID) listProgressQuest.RemoveAt(i);
        //}
    }

    public void NotifyLevelupToQuestData(int level)
    {
        //for (int i = 0; i < listQuestData.Count; ++i)
        //{
        //    if (listQuestData[i].QuestCondition.IsCanProgressLevel(level)) listPossibleQuest.Add(listQuestData[i]);
        //}
    }

    public void NotifyDoTask(int id)
    {
        for(int i = 0; i < listProgressQuest.Count; ++i)
        {
            if(listProgressQuest[i].Data.QuestTask.TargetId == id)
            {
                listProgressQuest[i].PlusAmount(1);
            }
        }
    }
}
