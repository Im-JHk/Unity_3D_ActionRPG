using UnityEngine;

[CreateAssetMenu(fileName = "DialogueData", menuName = "Dialogue/DialogueData")]
public class DialogueDataSO : ScriptableObject
{
    [SerializeField]
    private int speakerID;
    [SerializeField]
    private string speakerName;
    [SerializeField]
    private string[] dialogues;

    public int SpeakerID { get { return speakerID; } }
    public string SpeakerName { get { return name; } }
    public string[] Dialogues { get { return dialogues; } }

    public string GetDialogue(int index) { return dialogues[index]; }
    public bool IsEnd(int index) 
    {
        if (dialogues == null) return false;
        else return index >= dialogues.Length - 1; 
    }
}
