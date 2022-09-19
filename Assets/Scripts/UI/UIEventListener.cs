using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEventListener
{
    [SerializeField]
    private GameObject target = null;

    public void SetActiveToButton(int truefalse)
    {
        switch (truefalse)
        {
            case 0:
                target.GetComponent<Button>().interactable = false;
                target.GetComponent<Image>().color = Color.gray;
                break;
            case 1:
                target.GetComponent<Button>().interactable = true;
                target.GetComponent<Image>().color = Color.white;
                break;
        }
    }
}
