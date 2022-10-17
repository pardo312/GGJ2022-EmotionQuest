using System;
using TMPro;
using UnityEngine;

namespace EmotionQuest.GameplayModule.OrbModule
{
    public class OrbsManager : MonoBehaviour
    {
        [SerializeField, Range(.1f, 1)] private float valueOfGrowth;
        [SerializeField, Range(.1f, 10)] private float scaleGrowthRatio;

        [SerializeField] private OrbController sadnessOrb;
        [SerializeField] private OrbController happinessOrb;
        [SerializeField] private Color sadnessOrbColor;
        [SerializeField] private Color happinessOrbColor;
        [SerializeField] private TMP_Text orb_label;

        public event Action failNote;
        public event Action scoreNote;

        //currentStat positive = red  & negative = blue
        private int currentState = 0;

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
                scaleGrowthRatioToUse *= -1;
            currentState--;

            sadnessOrb.ChangeColorAndScaleOfOrb(valueOfGrowth, scaleGrowthRatioToUse);
            happinessOrb.ChangeColorAndScaleOfOrb(-valueOfGrowth, scaleGrowthRatioToUse);

            CheckIfActive();
            CheckLabel();
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

            CheckIfActive();
            CheckLabel();
        }

        public void CheckIfActive()
        {
            sadnessOrb.isActive = currentState <= 0;
            happinessOrb.isActive = currentState >= 0;
        }

        public void CheckLabel()
        {
            if (currentState == 0)
                orb_label.gameObject.SetActive(false);
            else
            {
                orb_label.gameObject.SetActive(true);
                string orb = happinessOrb.isActive ? "H" : "S";
                Color orbColor = happinessOrb.isActive ? happinessOrbColor : sadnessOrbColor;
                orb_label.text = orb + Math.Abs(currentState);
                orb_label.color = orbColor;
            }
        }
    }
}