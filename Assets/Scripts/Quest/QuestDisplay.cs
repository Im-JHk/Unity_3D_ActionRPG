using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDisplay : MonoBehaviour
{
    [SerializeField]
    private GameObject questScrollViewGO;
    [SerializeField]
    private GameObject listPrefab;

    public bool IsOpen { get; private set; }

    private void Awake()
    {
        IsOpen = false;
    }

    public void OnClickOpenList()
    {
        IsOpen = true;
        questScrollViewGO.SetActive(true);
    }

    public void OnClickCloseList()
    {
        questScrollViewGO.SetActive(false);
        IsOpen = false;
    }

    //public void AddList(QuestManager.)
}
