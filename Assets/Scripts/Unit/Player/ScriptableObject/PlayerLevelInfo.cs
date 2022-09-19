using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerLevelInfo", menuName = "ScriptableObject/PlayerLevelInfo")]
public class PlayerLevelInfo : ScriptableObject
{
    [SerializeField]
    private int[] listExpPerLevel;
    private int maxLevel = 20;
    private int baseExp = 10;

    public List<int> ListExpPerLevel { get; }

    #region Increase Value
    private float expIncreaseRatio = 1.5f;
    private int levelupToPoint = 5;
    private int hpIncreaseByLevelup = 40;
    private int mpIncreaseByLevelup = 20;
    private int atkIncreaseByLevelup = 20;
    private int defIncreaseByLevelup = 10;
    private int hpIncreaseByPointup = 20;
    private int mpIncreaseByPointup = 10;
    private int atkIncreaseByPointup = 10;
    private int defIncreaseByPointup = 5;

    public float ExpIncreaseRatio { get { return expIncreaseRatio; } }
    public int LevelupToPoint { get { return levelupToPoint; } }
    public int HpIncreaseByLevelup { get { return hpIncreaseByLevelup; } }
    public int MpIncreaseByLevelup { get { return mpIncreaseByLevelup; } }
    public int AtkIncreaseByLevelup { get { return atkIncreaseByLevelup; } }
    public int DefIncreaseByLevelup { get { return defIncreaseByLevelup; } }
    public int HpIncreaseByPointup { get { return hpIncreaseByPointup; } }
    public int MpIncreaseByPointup { get { return mpIncreaseByPointup; } }
    public int AtkIncreaseByPointup { get { return atkIncreaseByPointup; } }
    public int DefIncreaseByPointup { get { return defIncreaseByPointup; } }
    #endregion


    public void OnEnable()
    {
        Initialize();
    }

    public void Initialize()
    {
        listExpPerLevel = new int[maxLevel];
        listExpPerLevel[0] = 0;
        listExpPerLevel[1] = 200;
        for (int i = 2; i < maxLevel; ++i) listExpPerLevel[i] = Mathf.RoundToInt(listExpPerLevel[i - 1] * expIncreaseRatio);
    }

    public int GetExpPerLevel(int level)
    {
        return (level > maxLevel) ? listExpPerLevel[maxLevel] : listExpPerLevel[level];
    }
}
