using EmotionQuest.GameplayModule;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EmotionQuest.SceneFlowModule
{
    public class GameplaySceneController : SceneController
    {
        #region ----Fields----
        [SerializeField] private GameplayController gameplayController;
        #endregion ----Fields----

        #region ----Methods----
        public override void Init(Action<bool> _callback = null)
        {
            gameplayController.Init();
            StartCoroutine(Wait(_callback));
        }

        IEnumerator Wait(Action<bool> callback)
        {
            yield return new WaitForSeconds(2);
            callback?.Invoke(true);
        }
        #endregion ----Methods----
    }
}