using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestReward", menuName = "Quest/QuestReward")]
public class QuestReward : ScriptableObject
{
    [SerializeField]
    private ItemData[] items;
    [SerializeField]
    private float experience;
    [SerializeField]
    private int gold;

    public ItemData[] Items { get { return items; } }
    public float Experience { get { return experience; } }
    public int Gold { get { return gold; } }

}
