using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NS_Phase
{
    public class Defend : IBattlePhase
    {
        private Monster monster = null;
        private Action exit;
        private NS_Phase.PhaseType phaseType;

        public Defend(Monster monster)
        {
            phaseType = NS_Phase.PhaseType.Defend;
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