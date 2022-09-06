using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NS_Phase
{
    public class RushAttack : IBattlePhase
    {
        private Monster monster = null;
        private Action exit;
        private NS_Phase.PhaseType phaseType;

        public RushAttack(Monster monster)
        {
            phaseType = NS_Phase.PhaseType.RushAttack;
            exit += Exit;
            this.monster = monster;
        }

        public void Execute()
        {

        }

        public void Exit()
        {

        }
    }
}