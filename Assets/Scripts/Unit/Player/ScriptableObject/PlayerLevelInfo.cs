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
    private float expIncreaseRatio = 1.5f;

    public List<int> ListExpPerLevel { get; }

    public void OnEnable()
    {
        Initialize();
    }

    public void Initialize()
    {
        listExpPerLevel = new int[maxLevel];
        listExpPerLevel[0] = 0;
        for (int i = 1; i < maxLevel; ++i) listExpPerLevel[i] = Mathf.RoundToInt(listExpPerLevel[i - 1] * expIncreaseRatio);
    }

    public int GetExpPerLevel(int level)
    {
        return (level > maxLevel) ? listExpPerLevel[maxLevel] : listExpPerLevel[level];
    }
}
