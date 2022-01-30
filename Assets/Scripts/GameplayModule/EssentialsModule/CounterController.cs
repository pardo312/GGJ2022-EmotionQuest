using System;
using TMPro;
using UnityEngine;

namespace EmotionQuest.GameplayModule 
{
    public class CounterController : MonoBehaviour
    {
        #region ----Field----
        [SerializeField] private TMP_Text countdownTMP;
        [SerializeField, Range(3, 5)] private int initCountdown;
        #endregion ----Field----

        #region ----Methods----
        [ContextMenu("StartCounter")]
        public void StartCounter(Action callback)
        {
            countdownTMP.gameObject.SetActive(true);
            SetCountdownBegining(initCountdown, callback);
        }

        private void SetCountdownBegining(int countdownNumber, Action callback)
        {
            //Init
            countdownTMP.text = $"{countdownNumber}"; ;
            countdownTMP.transform.localScale = Vector3.one * 0.5f;

            //Change alpha
            LeanTween.value(countdownTMP.gameObject, 1, 0, 1).setOnUpdate((float value) =>
             {
                 countdownTMP.color = new Color(countdownTMP.color.r, countdownTMP.color.g, countdownTMP.color.b, value);
             });

            //Change scale
            LeanTween.scale(countdownTMP.gameObject, Vector3.one * 2, 1).setOnComplete(() =>
              {
                  if (countdownNumber - 1 > 0)
                  {
                      SetCountdownBegining(countdownNumber - 1, callback);
                  }
                  else
                  {
                      countdownTMP.gameObject.SetActive(false);
                      callback?.Invoke();
                  }
              });
        }
        #endregion ----Methods----
    }
}