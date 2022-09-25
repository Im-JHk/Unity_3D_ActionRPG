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
    [SerializeField]
    private bool isClearPrevQuest;
    [SerializeField]
    private bool isPossibleQuest;

    public int Level { get { return level; } }
    public int PrevQuestID { get { return prevQuestID; } }
    public bool IsClearPrevQuest { get { return isClearPrevQuest; } }
    public bool IsPossibleQuest { get { return isPossibleQuest; } }

    public bool UpdateIsPossible(int level)
    {
        if (level >= this.level && isClearPrevQuest)
        {
            isPossibleQuest = true;
            return true;
        }
        return false;
    }
    public void ClearQuestIsPrev(int questID) { if (!isClearPrevQuest && questID == prevQuestID) isClearPrevQuest = true; }
}
