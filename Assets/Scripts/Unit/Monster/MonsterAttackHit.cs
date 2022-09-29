using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttackHit : MonoBehaviour
{
    [SerializeField]
    private MonsterStat monsterStat;
    [SerializeField]
    private BoxCollider hitbox;
    public BoxCollider Hitbox { get { return hitbox; } private set { hitbox = value; } }

    private void Awake()
    {
        if (monsterStat == null) monsterStat = GetComponentInParent<MonsterStat>();
        Hitbox = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.GetComponentInParent<Player>();
            player.Damaged(monsterStat.Damage, transform.position - other.transform.position, other.ClosestPoint(transform.position));
        }
    }
}
