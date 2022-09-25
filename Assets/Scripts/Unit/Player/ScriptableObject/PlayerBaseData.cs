using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerBaseData", menuName = "ScriptableObject/Player/PlayerBaseData")]
public class PlayerBaseData : ScriptableObject
{
    [SerializeField]
    private float energy;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float damageRadius;
    [SerializeField]
    private int hp;
    [SerializeField]
    private int mp;
    [SerializeField]
    private int atk;
    [SerializeField]
    private int def;

    public float Energy { get { return energy; } }
    public float MoveSpeed { get { return moveSpeed; } }
    public float DamageRadius { get { return damageRadius; } }
    public int Hp { get { return hp; } }
    public int Mp { get { return mp; } }
    public int Atk { get { return atk; } }
    public int Def { get { return def; } }
}
