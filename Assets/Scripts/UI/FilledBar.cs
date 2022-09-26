using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilledBar : MonoBehaviour
{
    [SerializeField]
    private PlayerStat playerStat = null;
    [SerializeField]
    private Image hpBarImage;
    [SerializeField]
    private Image energyBarImage;
    [SerializeField]
    private Text levelText;

    private void Awake()
    {
        if (playerStat == null) playerStat = FindObjectOfType<PlayerStat>();
    }

    private void Start()
    {
        EventManager.Instance.AddAction(EventType.OnLevelup, UpdataLevelText);
        UpdataLevelText();
    }

    private void Update()
    {
        hpBarImage.fillAmount = playerStat.Hp / playerStat.HpMax;
        energyBarImage.fillAmount = playerStat.Hp / playerStat.HpMax;
    }

    public void UpdataLevelText()
    {
        levelText.text = playerStat.Level.ToString();
    }
}
