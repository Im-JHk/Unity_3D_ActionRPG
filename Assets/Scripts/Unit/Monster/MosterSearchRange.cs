using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosterSearchRange : MonoBehaviour
{
    [SerializeField]
    private Monster monster = null;
    [SerializeField]
    private SphereCollider rangeCollider = null;
    private float radius = 7f;
    private float distance = 1f;

    private void Awake()
    {
        rangeCollider = GetComponent<SphereCollider>();
    }
    private void Start()
    {
        rangeCollider.radius = radius;
        monster.SetStopDistance(distance);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            monster.FocusTarget(other.gameObject);
            monster.MonsterState.SetState(monster.DicMonsterState[Unit.BaseState.Run]);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            monster.TargettingOff();
            monster.MonsterState.SetState(monster.DicMonsterState[Unit.BaseState.Idle]);
        }
    }
}
