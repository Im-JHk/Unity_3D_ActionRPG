using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueDataSO", menuName = "Dialogue/DialogueDataSO")]
public class DialogueDataSO : ScriptableObject
{
    [SerializeField]
    private List<DialogueData> dialogues;
    public List<DialogueData> Dialogues { get { return dialogues; } }

    public string GetDialogue(int index) { return dialogues[index].dialogue; }
    public bool IsEnd(int index) 
    {
        if (dialogues == null) return false;
        else return index >= dialogues.Count - 1; 
    }
}
