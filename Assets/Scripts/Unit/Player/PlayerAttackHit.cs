using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackHit : MonoBehaviour
{
    [SerializeField]
    public BoxCollider Hitbox { get; set; }
    public float Damage { get; set; }

    private void Awake()
    {
        Hitbox = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
            print("trigger " + other);
            var monster = other.GetComponentInParent<Monster>();
            monster.Damaged(Damage);
        }
    }
}
