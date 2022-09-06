using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NS_Phase
{
    public class StandoffAttack : IBattlePhase
    {
        private Monster monster = null;
        private Action exit;
        private NS_Phase.PhaseType phaseType;

        public StandoffAttack(Monster monster)
        {
            phaseType = NS_Phase.PhaseType.StandoffAttack;
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
