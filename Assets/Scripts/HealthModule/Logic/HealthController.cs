using Jiufen.Audio;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace EmotionQuest.GameplayModule.HealthModule
{
    public class HealthController : MonoBehaviour
    {
        [SerializeField] private Image imageHealth;
        private float currentDamage;

        private const float MAX_LIFE = 1;

        public Action playerDead;

        public void Init()
        {
            currentDamage = 0;
        }

        public void DecreaseResource()
        {
            if (currentDamage < MAX_LIFE)
            {
                AudioJobOptions audioJobExtras = new AudioJobOptions(volumen: .5f);
                AudioManager.PlayAudio("SFX_FAIL", audioJobExtras);
                currentDamage += .1f;
            }
            else
            {
                playerDead?.Invoke();
            }

            UpdateView();
        }

        public void IncreaseResource()
        {
            if(currentDamage > 0)
                currentDamage -= .05f;

            UpdateView();
        }

        private void UpdateView()
        {
            Color healthColor = imageHealth.color;
            LeanTween.value(imageHealth.color.r, 1 - currentDamage, 0.5f)
                .setOnUpdate((float value) =>
                {
                    imageHealth.color = new Color(value, value, value, 1);
                });
        }
    }
}