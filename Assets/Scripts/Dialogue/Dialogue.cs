using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

[Serializable]
public struct DialogueUI
{
    public GameObject dialogueGO;
    public GameObject clickImageGO;
    public Text nameText;
    public Text dialogueText;
}

[Serializable]
public struct DialogueData
{
    [SerializeField]
    public int speakerIndex;
    [SerializeField]
    public string name;
    [SerializeField]
    public string dialogue;
}

public class Dialogue : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private List<DialogueData> listDialogueData;
    [SerializeField]
    private DialogueUI dialogueUI;

    [SerializeField]
    private float typeSpeed;
    [SerializeField]
    private int dialogueIndex;
    [SerializeField]
    private bool isPlayDialogue;
    [SerializeField]
    private bool isStart;

    void Awake()
    {
        Initialize();
    }

    public void Initialize()
    {
        typeSpeed = 0.1f;
        dialogueIndex = 0;
        isPlayDialogue = false;
        isStart = false;
    }

    public void SetDialogue(DialogueDataSO dialogueData)
    {
        listDialogueData = dialogueData.Dialogues;
    }

    public void MoveNextScript()
    {
        if (dialogueIndex < listDialogueData.Count - 1)
        {
            dialogueIndex += 1;
            StartDialogue(dialogueIndex);
        }
        else EndDialogue();
    }

    public void StartDialogue(int index = 0)
    {
        if (!isStart)
        {
            Initialize();
            isStart = true;
        }

        dialogueUI.dialogueGO.SetActive(true);
        dialogueUI.nameText.text = listDialogueData[dialogueIndex].name;
        dialogueUI.dialogueText.text = string.Empty;
        dialogueUI.clickImageGO.SetActive(false);

        if (!isPlayDialogue) StartCoroutine(nameof(PlayTypeScript));
    }

    public void EndDialogue()
    {
        isStart = false;
        dialogueUI.dialogueGO.SetActive(false);
    }

    public IEnumerator PlayTypeScript()
    {
        isPlayDialogue = true;

        foreach (var c in listDialogueData[dialogueIndex].dialogue.ToCharArray())
        {
            dialogueUI.dialogueText.text += c;
            yield return new WaitForSeconds(typeSpeed);
        }

        dialogueUI.clickImageGO.SetActive(true);
        isPlayDialogue = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            if (dialogueUI.dialogueText.text == listDialogueData[dialogueIndex].dialogue)
            {
                MoveNextScript();
            }
            else
            {
                StopCoroutine(nameof(PlayTypeScript));
                dialogueUI.dialogueText.text = listDialogueData[dialogueIndex].dialogue;
                dialogueUI.clickImageGO.SetActive(true);
                isPlayDialogue = false;
            }
        }
    }
}
