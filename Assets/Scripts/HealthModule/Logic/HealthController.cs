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

        public Action playerDead;

        public void Init()
        {
            currentDamage = 0;
        }

        public void DecreaseResource()
        {
            if (currentDamage < 1)
            {
                AudioJobOptions audioJobExtras = new AudioJobOptions(volumen: 0.5f);
                AudioManager.PlayAudio("SFX_FAIL", audioJobExtras);
                currentDamage += .1f;
            }
            else
            {
                playerDead?.Invoke();
            }

            UpdateView();
        }

        private void UpdateView()
        {
            Color healthColor = imageHealth.color;
            LeanTween.value(imageHealth.color.a, currentDamage, 0.1f)
                .setOnUpdate((float value) =>
                {
                    imageHealth.color = new Color(healthColor.r, healthColor.g, healthColor.b, value);
                });
        }
    }
}