using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField]
    private int npcID;
    [SerializeField]
    private List<QuestData> listQuestData;
    [SerializeField]
    private List<DialogueDataSO> listDialogueData;
}
