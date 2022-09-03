using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosterSearchRange : MonoBehaviour
{
    private Monster monster = null;
    [SerializeField]
    private SphereCollider rangeCollider = null;
    private float distance = 1.5f;

    private void Awake()
    {
        monster = GetComponentInParent<Monster>();
        rangeCollider = GetComponent<SphereCollider>();
    }
    private void Start()
    {
        monster.SetStopDistance(distance);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            monster.FocusTarget(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            monster.TargettingOff();
        }
    }
}
