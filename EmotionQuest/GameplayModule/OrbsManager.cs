using EmotionQuest.GameplayModule.OrbModule;
using UnityEngine;
using UnityEngine.UI;

namespace EmotionQuest.GameplayModule
{
    public class OrbsManager : MonoBehaviour
    {
        #region ----Fields----
        [SerializeField, Range(.1f, 1)] private float valueOfGrowth;
        [SerializeField, Range(.1f, 10)] private float scaleGrowthRatio;
        public OrbController sadnessOrb;
        public OrbController happinessOrb;
        #endregion ----Fields----

        #region ----Methods----
        public void GrowSaddness()
        {
            sadnessOrb.ChangeColorAndScaleOfOrb(valueOfGrowth);
            happinessOrb.ChangeColorAndScaleOfOrb(-valueOfGrowth);
        }

        public void GrowHapinness()
        {
            happinessOrb.ChangeColorAndScaleOfOrb(valueOfGrowth);
            sadnessOrb.ChangeColorAndScaleOfOrb(-valueOfGrowth);
        }

        private void ChangeColorAndScaleOfOrb(Image orb, float percentage)
        {
            Color orbColor = orb.color;
            if (orbColor.a + percentage < 0 || orbColor.a + percentage > 1)
                return;
            orb.color = new Color(orbColor.r, orbColor.g, orbColor.b, orbColor.a + percentage);
            orb.transform.localScale += Vector3.one * percentage * scaleGrowthRatio;
        }
        #endregion ----Methods----
    }
}