using UnityEngine;

[CreateAssetMenu(fileName = "DialogueData", menuName = "Dialogue/DialogueData")]
public class DialogueDataSO : ScriptableObject
{
    [SerializeField]
    private int id;
    [SerializeField]
    private string name;
    [SerializeField]
    private string[] dialogues;

    public string Name { get { return name; } }
    public string[] Dialogues { get { return dialogues; } }

    public string GetDialogue(int index) { return dialogues[index]; }
    public bool IsEnd(int index) 
    {
        if (dialogues == null) return false;
        else return index >= dialogues.Length - 1; 
    }
}
