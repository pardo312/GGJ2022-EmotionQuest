using System;
using TMPro;
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
        public Color sadnessOrbColor;
        public Color happinessOrbColor;
        public TMP_Text orb_label;
        #endregion ----Fields----

        #region ----Methods----
        public void Init()
        {
            sadnessOrb.Init(TypeOfOrb.SAD);
            sadnessOrb.scoreNote += () => scoreNote?.Invoke();
            sadnessOrb.failNote += () => failNote?.Invoke();

            happinessOrb.Init(TypeOfOrb.HAPPY);
            happinessOrb.scoreNote += () => scoreNote?.Invoke();
            happinessOrb.failNote += () => failNote?.Invoke();

            CheckIfActive();
        }

        private void OnDestroy()
        {
            sadnessOrb.scoreNote -= () => scoreNote?.Invoke();
            sadnessOrb.failNote -= () => failNote?.Invoke();

            happinessOrb.scoreNote -= () => scoreNote?.Invoke();
            happinessOrb.failNote -= () => failNote?.Invoke();
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
            CheckLabel();

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
            CheckLabel();

            happinessOrb.ChangeColorAndScaleOfOrb(valueOfGrowth, scaleGrowthRatioToUse);
            sadnessOrb.ChangeColorAndScaleOfOrb(-valueOfGrowth, scaleGrowthRatioToUse);
        }

        public void CheckIfActive()
        {
            if (currentState == 0)
            {
                sadnessOrb.isActive = true;
                happinessOrb.isActive = true;
            }
            else if (currentState < 0)
            {
                sadnessOrb.isActive = true;
                happinessOrb.isActive = false;
            }
            else if (currentState > 0)
            {
                happinessOrb.isActive = true;
                sadnessOrb.isActive = false;
            }
        }

        public void CheckLabel()
        {
            if (currentState == 0)
            {
                orb_label.gameObject.SetActive(false);
            }
            else
            {
                orb_label.gameObject.SetActive(true);
                string orb = happinessOrb.isActive ? "H" : "S";
                Color orbColor = happinessOrb.isActive ? happinessOrbColor : sadnessOrbColor;
                orb_label.text = orb + Math.Abs(currentState);
                orb_label.color = orbColor;
            }
        }
        #endregion ----Methods----
    }
}