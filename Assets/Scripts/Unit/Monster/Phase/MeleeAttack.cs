using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NS_Phase
{
    public class MeleeAttack : IBattlePhase
    {
        private Monster monster = null;
        private NS_Phase.PhaseType phaseType;

        public MeleeAttack(Monster monster)
        {
            this.phaseType = NS_Phase.PhaseType.MeleeAttack;
            this.monster = monster;
        }

        public void Execute()
        {
            if (!monster.IsStayCoroutine)
            {
                Debug.Log("melee execute");
                monster.StartCoroutine(nameof(monster.MeleeAttack));
            }
        }

        public void Exit()
        {
            Debug.Log("melee exit");
        }
    }
}
