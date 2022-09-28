using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestDetailViewUI : MonoBehaviour
{
    [SerializeField]
    private Text questName;
    [SerializeField]
    private Text questDescription;
    [SerializeField]
    private Text questTask;

    [SerializeField]
    private Button acceptButton;
    [SerializeField]
    private Button refuseButton;

    public void SetQuestName(string text) => questName.text = text;
    public void SetQuestDescription(string text) => questDescription.text = text;
    public void SetQuestTask(string text) => questTask.text = text;

    public void SetDetailViewUI(string name, string des, string task)
    {
        questName.text = name;
        questDescription.text = des;
        questTask.text = task;
    }

    public void SetButtonInterableIfInProgress(bool flag)
    {
        acceptButton.interactable = !flag;
        refuseButton.interactable = flag;
    }
}
