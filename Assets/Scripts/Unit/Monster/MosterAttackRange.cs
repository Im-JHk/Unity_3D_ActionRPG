using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosterAttackRange : MonoBehaviour
{
    [SerializeField]
    private Monster monster = null;
    [SerializeField]
    private BoxCollider rangeCollider = null;
    private Vector3 size = new Vector3(1.5f, 1f, 1.5f);

    private void Awake()
    {
        rangeCollider = GetComponent<BoxCollider>();
    }
    private void Start()
    {
        rangeCollider.size = size;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            monster.ChangeMoveAndAttackState(true);
            monster.MonsterState.SetState(monster.DicMonsterState[NS_Unit.BaseState.Attack]);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            monster.ChangeMoveAndAttackState(false);
            monster.MonsterState.SetState(monster.DicMonsterState[NS_Unit.BaseState.Run]);
        }
    }
}
