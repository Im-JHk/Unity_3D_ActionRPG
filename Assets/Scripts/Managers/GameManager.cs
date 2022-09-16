using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameManager : SingletonMono<GameManager>
{
    private Action gameoverAction;
    public bool IsGameover { get; private set; }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void AddGameoverAction(Action action)
    {
        gameoverAction += action;
    }
}
