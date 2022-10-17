using System;
using UnityEngine;
using UnityEngine.UI;

namespace EmotionQuest.GameplayModule.OrbModule
{
    public class OrbController : MonoBehaviour
    {
        [SerializeField] private Image orb;

        private OrbData orbData;
        public bool isActive;

        public event Action scoreNote;
        public event Action failNote;

        public void Init(TypeOfOrb pTypeOfOrb) =>
            orbData = new OrbData() { typeOfOrb = pTypeOfOrb, sizeOfOrb = SizeOfOrb.NEUTRAL };

        public void ChangeColorAndScaleOfOrb(float percentage, float scaleGrowthRatio)
        {
            Color orbColor = orb.color;
            if (orbColor.a + percentage < 0 || orbColor.a + percentage > 1)
                return;

            if (isActive)
            {
                if (percentage > 0 && orbData.sizeOfOrb != SizeOfOrb.BIG)
                    orbData.sizeOfOrb++;
                else if (percentage < 1 && orbData.sizeOfOrb != SizeOfOrb.NEUTRAL)
                    orbData.sizeOfOrb--;
            }

            orb.color = new Color(orbColor.r, orbColor.g, orbColor.b, orbColor.a + percentage);
            orb.transform.localScale += Vector3.one * Math.Abs(percentage) * scaleGrowthRatio;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent(out NoteController noteController))
                return;

            if (!isActive || !other.transform.parent.gameObject.activeSelf)
                return;

            if (noteController.orbData.typeOfOrb == orbData.typeOfOrb && noteController.orbData.sizeOfOrb == orbData.sizeOfOrb)
                scoreNote?.Invoke();
            else
                failNote?.Invoke();
            other.transform.parent.gameObject.SetActive(false);
        }
    }
}