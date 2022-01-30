using System;
using UnityEngine;

namespace EmotionQuest.InputModule
{
    public class InputController : MonoBehaviour
    {
        #region ----Fields----
        [SerializeField] private KeyCode growHappinessKey;
        [SerializeField] private KeyCode growSadnessKey;
        [SerializeField, Range(.1f, 1f)] private float timeForContinuousInput;
        [SerializeField, Range(.01f, .1f)] private float timeBetweenContinuosInputs;

        public Action growHappiness;
        public Action growSadness;

        private float timer = 0;
        #endregion ----Fields----

        #region ----Methods----
        void Update()
        {
            CheckInput(growHappinessKey, () => growHappiness?.Invoke());
            CheckInput(growSadnessKey, () => growSadness?.Invoke());
        }

        public bool continousInput;
        private void CheckInput(KeyCode keycode, Action callback)
        {
            if (Input.GetKeyDown(keycode))
            {
                callback?.Invoke();
            }
            else if (Input.GetKey(keycode))
            {
                float timeUsing = continousInput ? timeBetweenContinuosInputs : timeForContinuousInput;
                if (timer < timeUsing)
                {
                    timer += Time.deltaTime;
                    return;
                }

                timer = 0;
                if (!continousInput)
                    continousInput = true;
                callback?.Invoke();
            }
            else if (Input.GetKeyUp(keycode))
            {
                continousInput = false;
                timer = 0;
            }
        }
        #endregion ----Methods----
    }
}