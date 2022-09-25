using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    private QuestData data;
    [SerializeField]
    private int currentAmount;
    [SerializeField]
    private bool isProgress;

    public Quest(QuestData data) { this.data = data; }

    public QuestData Data { get { return data; } }
    public int CurrentAmount { get { return currentAmount; } }
    public bool IsProgress { get { return isProgress; } set { isProgress = value; } }

    public bool IsQuestComplete() { return currentAmount >= data.QuestTask.Amount; }
    public string GetProgressInfoToString() { return string.Format(data.QuestSummary + " {0} / {1}", currentAmount, data.QuestTask.Amount); }
}
