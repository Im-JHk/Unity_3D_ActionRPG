using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingletonMono<UIManager>
{
    public Action UpdateStatus { get; set; }
    public Action PointUp { get; set; }

    #region Status, Inventory
    public GameObject Status;

    public Animator[] TextAnim;

    public Button SwitchStatusButton;
    public Button SwitchInventoryButton;

    // Status
    public Text levelText;
    public Text hpText;
    public Text mpText;
    public Text atkText;
    public Text defText;
    public Text remainPointText;

    public Text expText;
    public Slider expSlider;

    public Button[] plusHpPointButton;
    public Button[] plusMpPointButton;
    public Button[] plusAtkPointButton;
    public Button[] plusDefPointButton;

    public Text plusHpPointText;
    public Text plusMpPointText;
    public Text plusAtkPointText;
    public Text plusDefPointText;

    public Text plusHpValueText;
    public Text plusMpValueText;
    public Text plusAtkValueText;
    public Text plusDefValueText;

    public readonly int HashUpTrigger = Animator.StringToHash("UpTrigger");
    // Inventory


    #endregion

    public void SetActiveStatus()
    {
        Status.SetActive(false);
    }
}
