using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NS_Phase
{
    public class BattlePhase
    {
        private List<IBattlePhase> listMonsterPhase = null;
        private IBattlePhase currentPhase = null;
        private float phaseTime;
        private int currentPhaseIndex;
        private int phaseMax;
        private bool phaseOn;

        private readonly float phaseDelay;

        #region properties
        public List<IBattlePhase> ListMonsterPhase { get { return listMonsterPhase; } }
        public IBattlePhase CurrentPhase { get { return currentPhase; } private set { currentPhase = value; } }
        public float PhaseTime { get { return phaseTime; } private set { phaseTime = value; } }
        public int CurrentPhaseIndex { get { return currentPhaseIndex; } set { currentPhaseIndex = value; } }
        public int PhaseMax { get { return phaseMax; } private set { phaseMax = value; } }
        public bool PhaseOn { get { return phaseOn; } set { phaseOn = value; } }
        #endregion

        public BattlePhase(int phaseMax, float phaseDelay = 1.5f)
        {
            listMonsterPhase = new List<IBattlePhase>();
            this.currentPhase = null;
            this.currentPhaseIndex = 0;
            this.phaseMax = phaseMax;
            this.phaseDelay = phaseDelay;
            this.phaseTime = 0;
            this.phaseOn = false;
        }

        public void PhaseUpdate()
        {
            if (phaseOn && currentPhase == null)
            {
                phaseTime += Time.deltaTime;
                if (phaseTime >= phaseDelay) NextPhase();
            }
        }

        public void PhaseExecute()
        {
            this.currentPhase.Execute();
        }

        public void PhaseExit()
        {
            this.currentPhase.Exit();
            this.currentPhase = null;
            this.phaseTime = 0;
        }

        public void SetPhase(IBattlePhase phase)
        {
            this.currentPhase = phase;
        }

        public void NextPhase()
        {
            if (currentPhaseIndex >= phaseMax - 1) currentPhaseIndex = 0;
            else currentPhaseIndex += 1;
            this.currentPhase = listMonsterPhase[currentPhaseIndex];
            this.currentPhase.Execute();
        }
    }
}