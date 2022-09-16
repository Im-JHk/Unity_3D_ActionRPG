using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EventManager : SingletonMono<EventManager>
{
    public Dictionary<EventType, Action> DicEvent { get; private set; }
    public Action OnGameover { get; }
    public Action OnLevelup { get; }
    public Action OnAttack { get; }
    public Action OnDamage { get; }
    public Action OnDie { get; }

    private void Awake()
    {    
        DicEvent = new Dictionary<EventType, Action>();
        DicEvent.Add(EventType.OnGameover, OnGameover);
        DicEvent.Add(EventType.OnLevelup, OnLevelup);
        DicEvent.Add(EventType.OnAttack, OnAttack);
        DicEvent.Add(EventType.OnDamage, OnDamage);
        DicEvent.Add(EventType.OnDie, OnDie);
    }
}
