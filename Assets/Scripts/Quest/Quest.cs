using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{
    [SerializeField]
    private QuestData data;
    [SerializeField]
    private int currentAmount;
    [SerializeField]
    private bool isProgress;

    public Quest(QuestData data) { this.data = data; this.currentAmount = 0; this.isProgress = false; }

    public QuestData Data { get { return data; } }
    public int CurrentAmount { get { return currentAmount; } }
    public bool IsProgress { get { return isProgress; } }

    public void SetIsProgress(bool flag) { isProgress = flag; }
    public void PlusAmount(int number)
    {
        if (currentAmount == data.QuestTask.Amount) return;
        currentAmount += number;
        if (currentAmount > data.QuestTask.Amount) currentAmount = data.QuestTask.Amount;
    }
    public bool IsQuestComplete() { return currentAmount >= data.QuestTask.Amount; }
    public string GetInProgressTaskToString() { return string.Format(data.QuestTaskString + " {0} / {1}", currentAmount, data.QuestTask.Amount); }
}
