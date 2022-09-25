using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : SingletonMono<QuestManager>
{
    [SerializeField]
    private List<QuestData> listQuestData;
    private List<QuestData> listPossibleQuest;
    private List<QuestData> listCompleteQuest;
    private List<Quest> listProgressQuest;

    public int GetPossibleIndex(int questID)
    {
        for (int i = 0; i < listPossibleQuest.Count; ++i)
        {
            if (listPossibleQuest[i].QuestID == questID && listPossibleQuest[i].QuestCondition.IsPossibleQuest) return i;
        }
        return -1;
    }

    public void AcceptQuest(int index)
    {
        listProgressQuest.Add(listPossibleQuest[index].CreateQuest());
    }

    public void NotifyClearQuest(int questID)
    {
        Debug.Log("questID: " + questID + " clear");
        for (int i = 0; i < listQuestData.Count; ++i)
        {
            listQuestData[i].QuestCondition.ClearQuestIsPrev(questID);
            listCompleteQuest.Add(listQuestData[i]);
        }
        for(int i = 0; i < listProgressQuest.Count; ++i)
        {
            if (listProgressQuest[i].Data.QuestID == questID) listProgressQuest.RemoveAt(i);
        }
    }

    public void NotifyLevelupToQuestData(int level)
    {
        for (int i = 0; i < listQuestData.Count; ++i)
        {
            if (listQuestData[i].QuestCondition.UpdateIsPossible(level)) listPossibleQuest.Add(listQuestData[i]);
        }
    }
}
