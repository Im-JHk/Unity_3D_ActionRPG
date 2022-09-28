using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStat : MonoBehaviour
{
    [SerializeField]
    public MonsterBaseData baseData { get; }

    public int Hp { get; private set; }

    public bool IsDead() { return Hp <= 0; }
    public bool Damaged(float damage)
    {
        Hp -= Mathf.CeilToInt(damage - baseData.Def);
        if (Hp < 0) Hp = 0;
        if (Hp <= 0) return true;
        return false;
    }
}
