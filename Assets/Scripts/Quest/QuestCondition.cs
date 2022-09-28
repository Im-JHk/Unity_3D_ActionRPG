using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestCondition", menuName = "Quest/QuestCondition")]
public class QuestCondition : ScriptableObject
{
    [SerializeField]
    private int level;
    [SerializeField]
    private int prevQuestID;

    public int Level { get { return level; } }
    public int PrevQuestID { get { return prevQuestID; } }

    public bool IsCanProgressLevel(int level) { return level >= this.level; }
    public bool IsPrevQuestClear(List<int> questIDs) 
    {
        if (prevQuestID == -1) return true;
        for(int i = 0; i < questIDs.Count; ++i)
        {
            if (questIDs[i] == prevQuestID) return true;
        }
        return false;
    }
}
