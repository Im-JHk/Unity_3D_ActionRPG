using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerBaseData", menuName = "ScriptableObject/PlayerBaseData")]
public class PlayerBaseData : ScriptableObject
{
    [SerializeField]
    private float hp;
    [SerializeField]
    private float mp;
    [SerializeField]
    private float energy;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float damageRadius;
    [SerializeField]
    private int atk;
    [SerializeField]
    private int def;

    public float Hp { get { return hp; } }
    public float Mp { get { return mp; } }
    public float Energy { get { return energy; } }
    public float MoveSpeed { get { return moveSpeed; } }
    public float DamageRadius { get { return damageRadius; } }
    public float Atk { get { return atk; } }
    public float Def { get { return def; } }
}
