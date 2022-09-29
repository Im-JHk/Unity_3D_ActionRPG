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
    [SerializeField]
    private Text hpBarText;
    [SerializeField]
    private Text energyBarText;

    public bool IsLevelUp { get; private set; }

    private void Awake()
    {
        if (playerStat == null) playerStat = FindObjectOfType<PlayerStat>();
        IsLevelUp = false;
    }

    private void Start()
    {
        EventManager.Instance.AddAction(EventType.OnLevelup, SetIsLevelUp);
        UpdateLevelText();
    }

    private void Update()
    {
        hpBarImage.fillAmount = (float)playerStat.Hp / (float)playerStat.HpMax;
        energyBarImage.fillAmount = (float)playerStat.Energy / (float)playerStat.EnergyMax;
        hpBarText.text = playerStat.Hp.ToString() + "/" + playerStat.HpMax.ToString();
        energyBarText.text = playerStat.Energy.ToString() + "/" + playerStat.EnergyMax.ToString();
        if (IsLevelUp) UpdateLevelText();
    }

    public void SetIsLevelUp() => IsLevelUp = true;
    public void UpdateLevelText()
    {
        if (levelText.text == playerStat.Level.ToString()) return;
        levelText.text = playerStat.Level.ToString();
        IsLevelUp = false;
    }
}
