using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosterAttackRange : MonoBehaviour
{
    private Monster monster = null;
    [SerializeField]
    private BoxCollider rangeCollider = null;

    private void Awake()
    {
        monster = GetComponentInParent<Monster>();
        rangeCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            monster.ChangeMoveAndAttackState(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            monster.ChangeMoveAndAttackState(false);
        }
    }
}
