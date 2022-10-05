using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterBaseData", menuName = "ScriptableObject/MonsterBaseData")]
public class MonsterBaseData : ScriptableObject
{
    [SerializeField]
    private int identity;
    [SerializeField]
    private int health;
    [SerializeField]
    private int energy;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float attackRadius;
    [SerializeField]
    private float damageRadius;
    [SerializeField]
    private int atk;
    [SerializeField]
    private int def;

    public int Identity { get { return identity; } }
    public int Health { get { return health; } }
    public int Energy { get { return energy; } }
    public float MoveSpeed { get { return moveSpeed; } }
    public float AttackRadius { get { return attackRadius; } }
    public float DamageRadius { get { return damageRadius; } }
    public float Atk { get { return atk; } }
    public float Def { get { return def; } }
}
