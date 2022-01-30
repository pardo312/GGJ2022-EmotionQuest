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
        public OrbController sadnessOrb;
        public OrbController happinessOrb;
        #endregion ----Fields----
        #region ----Methods----
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

            happinessOrb.ChangeColorAndScaleOfOrb(valueOfGrowth, scaleGrowthRatioToUse);
            sadnessOrb.ChangeColorAndScaleOfOrb(-valueOfGrowth, scaleGrowthRatioToUse);
        }
        #endregion ----Methods----
    }
}