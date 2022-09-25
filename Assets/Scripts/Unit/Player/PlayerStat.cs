using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStat : MonoBehaviour
{
    private Player player;
    [SerializeField]
    private PlayerBaseData data;
    [SerializeField]
    private PlayerLevelInfo levelInfo;

    private int level;
    private int hp;
    private int mp;
    private int hpPoint;
    private int mpPoint;
    private int atkPoint;
    private int defPoint;
    private int equipAtkValue;
    private int equipDefValue;
    private float exp;

    private int plusLevel;
    private int usePoint;
    private int remainPoint;
    private int plusHpPoint;
    private int plusMpPoint;
    private int plusAtkPoint;
    private int plusDefPoint;

    public int Level { get { return level; } }

    public void GetExp(float exp)
    {
        print(levelInfo.GetExpPerLevel(level));
        this.exp += exp;

        while (this.exp >= levelInfo.GetExpPerLevel(level))
        {
            this.exp -= levelInfo.GetExpPerLevel(level);
            plusLevel += 1;
        }
        UIManager.Instance.expText.text = string.Format("{0}/{1}", this.exp, levelInfo.GetExpPerLevel(level));
        UIManager.Instance.expSlider.value = this.exp / levelInfo.GetExpPerLevel(level);
        if (plusLevel > 0) { EventManager.Instance.DicEvent[EventType.OnLevelup].Invoke(); }
    }

    public void LevelUp()
    {
        level += plusLevel;
        remainPoint += plusLevel * levelInfo.LevelupToPoint;
        hp = data.Hp + ((level - 1) * levelInfo.HpIncreaseByLevelup);
        mp = data.Mp + ((level - 1) * levelInfo.MpIncreaseByLevelup);
        UIManager.Instance.plusHpValueText.text = string.Format("+{0}", plusLevel * levelInfo.HpIncreaseByLevelup);
        UIManager.Instance.plusMpValueText.text = string.Format("+{0}", plusLevel * levelInfo.MpIncreaseByLevelup);
        UIManager.Instance.plusAtkValueText.text = string.Format("+{0}", plusLevel * levelInfo.AtkIncreaseByLevelup);
        UIManager.Instance.plusDefValueText.text = string.Format("+{0}", plusLevel * levelInfo.DefIncreaseByLevelup);
        plusLevel = 0;
    }

    public void UpdateStatusUI()
    {
        UIManager.Instance.levelText.text = level.ToString();
        UIManager.Instance.hpText.text = string.Format("{0}/{1}", hp, data.Hp + ((level - 1) * levelInfo.HpIncreaseByLevelup) + (hpPoint * levelInfo.HpIncreaseByPointup));
        UIManager.Instance.mpText.text = string.Format("{0}/{1}", mp, data.Mp + ((level - 1) * levelInfo.MpIncreaseByLevelup) + (mpPoint * levelInfo.MpIncreaseByPointup));
        UIManager.Instance.atkText.text = (data.Atk + ((level - 1) * levelInfo.AtkIncreaseByLevelup) + (atkPoint * levelInfo.AtkIncreaseByPointup) + equipAtkValue).ToString();
        UIManager.Instance.defText.text = (data.Def + ((level - 1) * levelInfo.DefIncreaseByLevelup) + (defPoint * levelInfo.DefIncreaseByPointup) + equipDefValue).ToString();
        UIManager.Instance.remainPointText.text = remainPoint.ToString();
        UIManager.Instance.expText.text = string.Format("{0}/{1}", this.exp, levelInfo.GetExpPerLevel(level));
        UIManager.Instance.expSlider.value = this.exp / levelInfo.GetExpPerLevel(level);
        if (remainPoint > 0) PointButtonSetActive(1, true);
        else PointButtonSetActive(1, false);
    }

    public void SetEquipedStats(int atk, int def)
    {
        equipAtkValue = atk;
        equipDefValue = def;
    }

    public void EnableTextAnim()
    {
        if (UIManager.Instance.plusHpValueText.text != "+0")
        {
            UIManager.Instance.plusHpValueText.enabled = true;
            UIManager.Instance.TextAnim[0].SetTrigger(UIManager.Instance.HashUpTrigger);
        }
        if (UIManager.Instance.plusMpValueText.text != "+0")
        {
            UIManager.Instance.plusMpValueText.enabled = true;
            UIManager.Instance.TextAnim[1].SetTrigger(UIManager.Instance.HashUpTrigger);
        }
        if (UIManager.Instance.plusAtkValueText.text != "+0")
        {
            UIManager.Instance.plusAtkValueText.enabled = true;
            UIManager.Instance.TextAnim[2].SetTrigger(UIManager.Instance.HashUpTrigger);
        }
        if (UIManager.Instance.plusDefValueText.text != "+0")
        {
            UIManager.Instance.plusDefValueText.enabled = true;
            UIManager.Instance.TextAnim[3].SetTrigger(UIManager.Instance.HashUpTrigger);
        }
    }

    public void DisableTextAnim()
    {
        UIManager.Instance.plusHpValueText.text = "+0";
        UIManager.Instance.plusMpValueText.text = "+0";
        UIManager.Instance.plusAtkValueText.text = "+0";
        UIManager.Instance.plusDefValueText.text = "+0";
        UIManager.Instance.plusHpValueText.enabled = false;
        UIManager.Instance.plusMpValueText.enabled = false;
        UIManager.Instance.plusAtkValueText.enabled = false;
        UIManager.Instance.plusDefValueText.enabled = false;
    }

    public void ClickButtonPlusPoint(int type)
    {
        switch ((StatPointType)type)
        {
            case StatPointType.Hp:
                plusHpPoint += 1;
                UIManager.Instance.plusHpPointText.text = plusHpPoint.ToString();
                if (plusHpPoint > 0)
                {
                    UIManager.Instance.plusHpPointButton[0].GetComponent<Button>().interactable = true;
                    UIManager.Instance.plusHpPointButton[0].image.color = Color.white;
                }
                break;
            case StatPointType.Mp:
                plusMpPoint += 1;
                UIManager.Instance.plusMpPointText.text = plusMpPoint.ToString();
                if (plusMpPoint > 0)
                {
                    UIManager.Instance.plusMpPointButton[0].GetComponent<Button>().interactable = true;
                    UIManager.Instance.plusMpPointButton[0].image.color = Color.white;
                }
                break;
            case StatPointType.ATK:
                plusAtkPoint += 1;
                UIManager.Instance.plusAtkPointText.text = plusAtkPoint.ToString();
                if (plusAtkPoint > 0)
                {
                    UIManager.Instance.plusAtkPointButton[0].GetComponent<Button>().interactable = true;
                    UIManager.Instance.plusAtkPointButton[0].image.color = Color.white;
                }
                break;
            case StatPointType.DEF:
                plusDefPoint += 1;
                UIManager.Instance.plusDefPointText.text = plusDefPoint.ToString();
                if (plusDefPoint > 0)
                {
                    UIManager.Instance.plusDefPointButton[0].GetComponent<Button>().interactable = true;
                    UIManager.Instance.plusDefPointButton[0].image.color = Color.white;
                }
                break;
        }

        usePoint += 1;
        remainPoint -= 1;
        UIManager.Instance.remainPointText.text = remainPoint.ToString();
        if (remainPoint <= 0) PointButtonSetActive(1, false);
    }

    public void ClickButtonMinusPoint(int type)
    {
        switch ((StatPointType)type)
        {
            case StatPointType.Hp:
                plusHpPoint -= 1;
                UIManager.Instance.plusHpPointText.text = plusHpPoint.ToString();
                if (plusHpPoint <= 0) 
                {
                    UIManager.Instance.plusHpPointButton[0].GetComponent<Button>().interactable = false;
                    UIManager.Instance.plusHpPointButton[0].image.color = Color.gray;
                }
                break;
            case StatPointType.Mp:
                plusMpPoint -= 1;
                UIManager.Instance.plusMpPointText.text = plusMpPoint.ToString();
                if (plusMpPoint <= 0)
                {
                    UIManager.Instance.plusMpPointButton[0].GetComponent<Button>().interactable = false;
                    UIManager.Instance.plusMpPointButton[0].image.color = Color.gray;
                }
                break;
            case StatPointType.ATK:
                plusAtkPoint -= 1;
                UIManager.Instance.plusAtkPointText.text = plusAtkPoint.ToString();
                if (plusAtkPoint <= 0)
                {
                    UIManager.Instance.plusAtkPointButton[0].GetComponent<Button>().interactable = false;
                    UIManager.Instance.plusAtkPointButton[0].image.color = Color.gray;
                }
                break;
            case StatPointType.DEF:
                plusDefPoint -= 1;
                UIManager.Instance.plusDefPointText.text = plusDefPoint.ToString();
                if (plusDefPoint <= 0)
                {
                    UIManager.Instance.plusDefPointButton[0].GetComponent<Button>().interactable = false;
                    UIManager.Instance.plusDefPointButton[0].image.color = Color.gray;
                }
                break;
        }

        usePoint -= 1;
        remainPoint += 1;
        UIManager.Instance.remainPointText.text = remainPoint.ToString();
        if (remainPoint > 0) PointButtonSetActive(1, true);
    }

    public void PointButtonSetActive(int direction, bool active)
    {
        Color color = (active == true) ? Color.white : Color.gray;
        UIManager.Instance.plusHpPointButton[direction].GetComponent<Button>().interactable = active;
        UIManager.Instance.plusMpPointButton[direction].GetComponent<Button>().interactable = active;
        UIManager.Instance.plusAtkPointButton[direction].GetComponent<Button>().interactable = active;
        UIManager.Instance.plusDefPointButton[direction].GetComponent<Button>().interactable = active;
        UIManager.Instance.plusHpPointButton[direction].image.color = color;
        UIManager.Instance.plusMpPointButton[direction].image.color = color;
        UIManager.Instance.plusDefPointButton[direction].image.color = color;
        UIManager.Instance.plusAtkPointButton[direction].image.color = color;
    }

    public void ClickButtonCancelPoint()
    {
        remainPoint += usePoint;
        usePoint = 0;
        plusHpPoint = 0;
        plusMpPoint = 0;
        plusAtkPoint = 0;
        plusDefPoint = 0;
        UIManager.Instance.plusHpPointText.text = plusHpPoint.ToString();
        UIManager.Instance.plusMpPointText.text = plusMpPoint.ToString();
        UIManager.Instance.plusAtkPointText.text = plusAtkPoint.ToString();
        UIManager.Instance.plusDefPointText.text = plusDefPoint.ToString();
        UIManager.Instance.remainPointText.text = remainPoint.ToString();

        if (remainPoint > 0) PointButtonSetActive(1, true);
        else PointButtonSetActive(1, false);
    }

    public void ClickButtonAcceptPoint()
    {
        hpPoint += plusHpPoint;
        mpPoint += plusMpPoint;
        atkPoint += plusAtkPoint;
        defPoint += plusDefPoint;
        hp += plusHpPoint * levelInfo.HpIncreaseByPointup;
        mp += plusMpPoint * levelInfo.MpIncreaseByPointup;
        UIManager.Instance.plusHpValueText.text = string.Format("+{0}", plusHpPoint * levelInfo.HpIncreaseByPointup);
        UIManager.Instance.plusMpValueText.text = string.Format("+{0}", plusMpPoint * levelInfo.MpIncreaseByPointup);
        UIManager.Instance.plusAtkValueText.text = string.Format("+{0}", plusAtkPoint * levelInfo.AtkIncreaseByPointup);
        UIManager.Instance.plusDefValueText.text = string.Format("+{0}", plusDefPoint * levelInfo.DefIncreaseByPointup);
        UpdateStatusUI();
        EnableTextAnim();

        usePoint = 0;
        plusHpPoint = 0;
        plusMpPoint = 0;
        plusAtkPoint = 0;
        plusDefPoint = 0;
        UIManager.Instance.plusHpPointText.text = plusHpPoint.ToString();
        UIManager.Instance.plusMpPointText.text = plusMpPoint.ToString();
        UIManager.Instance.plusAtkPointText.text = plusAtkPoint.ToString();
        UIManager.Instance.plusDefPointText.text = plusDefPoint.ToString();

        if (remainPoint > 0) PointButtonSetActive(1, true);
        else PointButtonSetActive(1, false);
    }

    void Awake()
    {
        player = GetComponent<Player>();
        DisableTextAnim();
        PointButtonSetActive(0, false);
        PointButtonSetActive(1, false);
        level = 1;
        hp = data.Hp;
        mp = data.Mp;
        hpPoint = 0;
        mpPoint = 0;
        atkPoint = 0;
        defPoint = 0;
        equipAtkValue = 0;
        equipDefValue = 0;
        exp = 0;
        remainPoint = 0;
        plusHpPoint = 0;
        plusMpPoint = 0;
        plusAtkPoint = 0;
        plusDefPoint = 0;
    }

    private void Start()
    {
        EventManager.Instance.AddAction(EventType.OnLevelup, LevelUp);
        EventManager.Instance.AddAction(EventType.OnLevelup, UpdateStatusUI);
        EventManager.Instance.AddAction(EventType.OnLevelup, EnableTextAnim);
    }

    void Update()
    {
        
    }
}
