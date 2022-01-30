using System;
using UnityEngine;
using UnityEngine.UI;

namespace EmotionQuest.GameplayModule.OrbModule
{
    public class OrbController : MonoBehaviour
    {
        #region ----Fields----
        [SerializeField] private Image orb;
        private OrbData orbData;
        public bool isActive;

        public Action scoreNote;
        public Action failNote;
        #endregion ----Fields----

        #region ----Methods----
        public void Init(TypeOfOrb pTypeOfOrb)
        {
            orbData = new OrbData() { typeOfOrb = pTypeOfOrb, sizeOfOrb = SizeOfOrb.NEUTRAL };
        }

        public void ChangeColorAndScaleOfOrb(float percentage, float scaleGrowthRatio)
        {
            Color orbColor = orb.color;
            if (orbColor.a + percentage < 0 || orbColor.a + percentage > 1)
                return;

            if (percentage > 0 && orbData.sizeOfOrb != SizeOfOrb.BIG)
                orbData.sizeOfOrb++;
            else if (percentage < 0 && orbData.sizeOfOrb != SizeOfOrb.NEUTRAL)
                orbData.sizeOfOrb--;

            orb.color = new Color(orbColor.r, orbColor.g, orbColor.b, orbColor.a + percentage);

            orb.transform.localScale += Vector3.one * Math.Abs(percentage) * scaleGrowthRatio;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<NoteController>(out NoteController noteController))
            {

                if (noteController.orbData.typeOfOrb == this.orbData.typeOfOrb
                    && noteController.orbData.sizeOfOrb == this.orbData.sizeOfOrb)
                {
                    if (isActive)
                    {
                        Debug.Log("Score in");
                        scoreNote?.Invoke();
                    }
                }
                else
                {
                    Debug.Log("fail in");
                    failNote?.Invoke();
                }

                other.gameObject.SetActive(false);
            }
        }
        #endregion ----Methods----
    }
}