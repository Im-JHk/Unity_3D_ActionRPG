using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestData", menuName = "Quest/QuestData")]
public class QuestData : ScriptableObject
{
    [SerializeField]
    private int employerID;
    [SerializeField]
    private int questID;
    [SerializeField]
    private string questName;
    [SerializeField]
    private string questDescription;
    [SerializeField]
    private string questTaskString;

    [SerializeField]
    private QuestCondition questCondition;
    [SerializeField]
    private QuestTask questTask;
    [SerializeField]
    private QuestReward questReward;

    public int EmployerID { get { return employerID; } }
    public int QuestID { get { return questID; } }
    public string QuestName { get { return questName; } }
    public string QuestDescription { get { return questDescription; } }
    public string QuestTaskString { get { return questTaskString; } }

    public QuestCondition QuestCondition { get { return questCondition; } }
    public QuestTask QuestTask { get { return questTask; } }
    public QuestReward QuestReward { get { return questReward; } }

    public Quest CreateQuest() { return new Quest(this); }
}
