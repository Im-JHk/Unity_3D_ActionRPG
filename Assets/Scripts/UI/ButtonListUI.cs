using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonListUI : MonoBehaviour
{
    [SerializeField]
    private GameObject openImage;
    [SerializeField]
    private GameObject closeImage;

    [SerializeField]
    private GameObject statusButtonGO;
    [SerializeField]
    private GameObject inventoryButtonGO;
    [SerializeField]
    private GameObject questButtonGO;

    public bool IsOpen { get; private set; }

    private void Awake()
    {
        IsOpen = false;
    }

    public void OnClickOpenList()
    {
        openImage.SetActive(false);
        closeImage.SetActive(true);

        statusButtonGO.SetActive(true);
        inventoryButtonGO.SetActive(true);
        questButtonGO.SetActive(true);

        IsOpen = true;
    }

    public void OnClickCloseList()
    {
        openImage.SetActive(true);
        closeImage.SetActive(false);

        statusButtonGO.SetActive(false);
        inventoryButtonGO.SetActive(false);
        questButtonGO.SetActive(false);

        IsOpen = false;
    }
}
