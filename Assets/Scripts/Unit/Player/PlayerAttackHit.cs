using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackHit : MonoBehaviour
{
    [SerializeField]
    private PlayerStat playerStat;
    [SerializeField]
    private BoxCollider hitbox;
    public BoxCollider Hitbox { get { return hitbox; } private set { hitbox = value; } }

    private void Awake()
    {
        if (playerStat == null) playerStat = GetComponentInParent<PlayerStat>();
        Hitbox = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
            var monster = other.GetComponentInParent<Monster>();
            monster.Damaged(playerStat.Damage, transform.position - other.transform.position , other.ClosestPoint(transform.position));
        }
    }
}
