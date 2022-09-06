using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NS_Phase
{
    public class BattlePhase
    {
        private IBattlePhase currentPhase = null;
        private float phaseTime;
        private float phaseDelay;
        private int phaseMax;
        private bool phaseOn;

        public IBattlePhase CurrentPhase { get { return currentPhase; } private set { currentPhase = value; } }
        public float PhaseTime { get { return phaseTime; } private set { phaseTime = value; } }
        public int PhaseMax { get { return phaseMax; } private set { phaseMax = value; } }
        public bool PhaseOn { get { return phaseOn; } private set { phaseOn = value; } }

        public BattlePhase(int phaseMax, float phaseDelay = 1.5f)
        {
            this.currentPhase = null;
            this.phaseMax = phaseMax;
            this.phaseDelay = phaseDelay;
            this.phaseTime = 0;
            this.phaseOn = false;
        }

        public void PhaseUpdate()
        {
            if (phaseOn && currentPhase != null)
            {
                phaseTime += Time.deltaTime;
            }
        }

        public void SetPhase(IBattlePhase phase)
        {
            if (this.currentPhase == phase)
            {
                return;
            }
            this.currentPhase.Exit();
            this.currentPhase = phase;
            this.currentPhase.Execute();
        }
    }
}