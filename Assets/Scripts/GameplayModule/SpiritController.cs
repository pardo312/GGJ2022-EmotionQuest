using UnityEngine;
using UnityEngine.UI;

namespace EmotionQuest.GameplayModule
{
    public class SpiritController : MonoBehaviour
    {
        #region ----Fields----
        [SerializeField,Range(.1f,1)] private float valueOfGrowth;
        [SerializeField,Range(.1f,10)] private float scaleGrowthRatio;
        public Image sadnessOrb;
        public Image happinessOrb;
        #endregion ----Fields----

        #region ----Methods----
        public void GrowSaddness()
        {
            ChangeColorAndScaleOfOrb(sadnessOrb, valueOfGrowth);
            ChangeColorAndScaleOfOrb(happinessOrb, -valueOfGrowth);
        }

        public void GrowHapinness()
        {
            ChangeColorAndScaleOfOrb(happinessOrb, valueOfGrowth);
            ChangeColorAndScaleOfOrb(sadnessOrb, -valueOfGrowth);
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