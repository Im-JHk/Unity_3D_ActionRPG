using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStat : MonoBehaviour
{
    [SerializeField]
    private MonsterBaseData data;

    public MonsterBaseData Data { get { return data; } private set { data = value; } }
    public int Hp { get; private set; }
    public float Damage { get { return data.Atk; } }
    public bool IsDead { get { return Hp <= 0; } }
    public bool Damaged(float damage)
    {
        Hp -= Mathf.CeilToInt(damage - data.Def);
        if (Hp < 0) Hp = 0;
        if (Hp <= 0) return true;
        return false;
    }
}
