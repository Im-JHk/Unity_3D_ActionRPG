using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestTask", menuName = "Quest/QuestTask")]
public class QuestTask : ScriptableObject
{
    [SerializeField]
    private int targetId;
    [SerializeField]
    private int amount;

    public int TargetId { get { return targetId; } }
    public int Amount { get { return amount; } }

    public bool IsTarget(int id) { return targetId == id; }
    public bool IsCompleteTask(int amount) { return amount >= this.amount; }
    public string GetPrintTaskToString(string task, int amount) { return string.Format("{0} {1} / {2}", task, amount, this.amount); }
}
