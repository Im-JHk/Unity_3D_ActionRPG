using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum PlayerState
    {
        Idle,
        Walk,
        Run,
        Attack,
        Defend,
        Dodge,
    }

    public enum PlayerMoveState
    {
        None = 0,
        Walk,
        Run
    }
    private Rigidbody rigidbody = null;

    public Rigidbody GetRigidbody { get { return rigidbody; } set { rigidbody = value; } }

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
