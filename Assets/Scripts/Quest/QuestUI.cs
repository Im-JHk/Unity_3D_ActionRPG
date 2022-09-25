using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestUI : MonoBehaviour
{
    [SerializeField]
    private GameObject informationGO;
    [SerializeField]
    private GameObject slotPrefab;
    [SerializeField]
    private Transform contentSpace;
    [SerializeField]
    private Button acceptGO;
    [SerializeField]
    private Button refuseGO;

    private List<QuestSlotUI> listSlotUI;

    private void Awake()
    {
        listSlotUI = new List<QuestSlotUI>();
    }

    public void CreateSlot()
    {
        int index = listSlotUI.Count;

        GameObject newSlot = Instantiate(slotPrefab);
        RectTransform rectTransform = newSlot.GetComponent<RectTransform>();
        rectTransform.SetParent(contentSpace);
        rectTransform.gameObject.name = $"Slot[{index}]";
        rectTransform.gameObject.SetActive(true);

        QuestSlotUI slotUI = newSlot.GetComponent<QuestSlotUI>();
        slotUI.SetIndex(index);
        slotUI.SetQuestRefference(this);
        listSlotUI.Add(slotUI);
    }
}
