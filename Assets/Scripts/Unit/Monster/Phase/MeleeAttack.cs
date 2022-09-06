using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NS_Phase
{
    public class MeleeAttack : IBattlePhase
    {
        private Monster monster = null;
        private Action exit;
        private NS_Phase.PhaseType phaseType;

        public MeleeAttack(Monster monster)
        {
            phaseType = NS_Phase.PhaseType.MeleeAttack;
            exit += Exit;
            this.monster = monster;
        }

        public void Execute()
        {
            monster.StartCoroutine(nameof(MeleeAttack), exit);
        }
        public void Exit()
        {
            monster.NextPhase();
        }
    }
}
