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
    //private float distance = 2f;

    private void Awake()
    {
        rangeCollider = GetComponent<SphereCollider>();
    }
    private void Start()
    {
        rangeCollider.radius = radius;
        //monster.SetStopDistance(distance);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            monster.FocusTarget(other.gameObject);
            if (monster is Turtle turtle)
            {
                //turtle.isD
            } 
            monster.StateMachine.SetState(monster.DicMonsterState[NS_Unit.BaseState.Run]);
            //monster.MonsterPhase.PhaseOn = true;
            //monster.MonsterPhase.PhaseExecute();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            monster.TargettingOff();
            monster.StateMachine.SetState(monster.DicMonsterState[NS_Unit.BaseState.Idle]);
        }
    }
}
