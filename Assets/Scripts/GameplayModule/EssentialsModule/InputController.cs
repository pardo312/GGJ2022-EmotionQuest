using System;
using UnityEngine;

namespace EmotionQuest.InputModule
{
    public class InputController : MonoBehaviour
    {
        [SerializeField] private KeyCode growHappinessKey;
        [SerializeField] private KeyCode growSadnessKey;
        [SerializeField, Range(.1f, 1f)] private float timeForContinuousInput;
        [SerializeField, Range(.01f, .1f)] private float timeBetweenContinuosInputs;

        [SerializeField] private bool continousInput;

        public Action growHappiness;
        public Action growSadness;

        private float timer = 0;

        void Update()
        {
            if (!CheckInput(growHappinessKey, () => growHappiness?.Invoke()))
                return;

            CheckInput(growSadnessKey, () => growSadness?.Invoke());
        }

        private bool CheckInput(KeyCode keycode, Action callback)
        {
            if (Input.GetKeyDown(keycode))
            {
                callback?.Invoke();
                return false;
            }
            else if (Input.GetKey(keycode))
            {
                float timeUsing = continousInput ? timeBetweenContinuosInputs : timeForContinuousInput;
                if (timer < timeUsing)
                {
                    timer += Time.deltaTime;
                    return false;
                }

                timer = 0;
                if (!continousInput)
                    continousInput = true;
                callback?.Invoke();
                return false;
            }
            else if (Input.GetKeyUp(keycode))
            {
                continousInput = false;
                timer = 0;
            }

            return true;
        }
    }
}