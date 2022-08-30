using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour, IMovable
{
    public enum UnitType
    {
        Player = 0,
        Monster
    }

    protected UnitType unitType;
    protected Vector3 moveVector;
    protected float rotateTime;
    protected bool isRun;

    public Vector3 MoveVector { get { return moveVector; } set { moveVector = value; } }
    public float RotateTime { get { return rotateTime; } set { rotateTime = value; } }
    public bool IsRun { get { return isRun; } set { isRun = value; } }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    virtual public void Move()
    {

    }

    virtual public void Rotate()
    {

    }
}
