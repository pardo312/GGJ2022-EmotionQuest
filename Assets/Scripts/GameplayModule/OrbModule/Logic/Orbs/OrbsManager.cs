using System;
using UnityEngine;
using UnityEngine.UI;

namespace EmotionQuest.GameplayModule.OrbModule
{
    public class OrbsManager : MonoBehaviour
    {
        #region ----Fields----
        [SerializeField, Range(.1f, 1)] private float valueOfGrowth;
        [SerializeField, Range(.1f, 10)] private float scaleGrowthRatio;
        //currentStat positive= red  & negative = blue
        private int currentState = 0;

        public Action failNote;
        public Action scoreNote;

        public OrbController sadnessOrb;
        public OrbController happinessOrb;
        #endregion ----Fields----
        #region ----Methods----
        public void Init()
        {
            sadnessOrb.scoreNote += () => scoreNote?.Invoke();
            sadnessOrb.failNote += () => failNote?.Invoke();
        }

        private void OnDestroy()
        {
            sadnessOrb.scoreNote -= () => scoreNote?.Invoke();
            sadnessOrb.failNote -= () => failNote?.Invoke();
        }

        public void GrowSaddness()
        {
            if (currentState < -2)
                return;

            float scaleGrowthRatioToUse = scaleGrowthRatio;
            if (currentState > 0)
            {
                scaleGrowthRatioToUse *= -1;
            }
            currentState--;

            CheckIfActive();

            sadnessOrb.ChangeColorAndScaleOfOrb(valueOfGrowth, scaleGrowthRatioToUse);
            happinessOrb.ChangeColorAndScaleOfOrb(-valueOfGrowth, scaleGrowthRatioToUse);
        }

        public void GrowHapinness()
        {
            if (currentState > 2)
                return;

            float scaleGrowthRatioToUse = scaleGrowthRatio;
            if (currentState < 0)
                scaleGrowthRatioToUse *= -1;
            currentState++;

            CheckIfActive();

            happinessOrb.ChangeColorAndScaleOfOrb(valueOfGrowth, scaleGrowthRatioToUse);
            sadnessOrb.ChangeColorAndScaleOfOrb(-valueOfGrowth, scaleGrowthRatioToUse);
        }

        public void CheckIfActive()
        {
            if (currentState == 0)
            {
                sadnessOrb.isActive = false;
                happinessOrb.isActive = false;
            }
            else if (currentState < 0)
            {
                sadnessOrb.isActive = true;
                happinessOrb.isActive = false;
            }
            else
            {
                happinessOrb.isActive = true;
                sadnessOrb.isActive = false;
            }
        }
        #endregion ----Methods----
    }
}