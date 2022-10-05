using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStat : MonoBehaviour
{
    [SerializeField]
    private Monster monster;
    [SerializeField]
    private MonsterBaseData data;

    public MonsterBaseData Data { get { return data; } private set { data = value; } }
    public int Hp { get; private set; }
    public float Damage { get { return data.Atk; } }
    public bool IsDead { get { return Hp <= 0; } }

    private void Awake()
    {
        monster = GetComponent<Monster>();
        Hp = data.Health;
    }

    public bool Damaged(float damage)
    {
        float getDamage = damage - data.Def * 0.5f;
        if (monster.IsDefend) getDamage *= 0.5f;
        Hp -= Mathf.CeilToInt(getDamage);
        if (Hp < 0) Hp = 0;
        if (Hp <= 0) return true;
        return false;
    }
}
