using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class QuestSlotUI : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private QuestUI questUI;

    public int Index { get; private set; }

    public void SetIndex(int index) => Index = index;
    public void SetQuestRefference(QuestUI questUI) => this.questUI = questUI;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {

        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
