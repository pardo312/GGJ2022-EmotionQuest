using EmotionQuest.GameplayModule;
using System;
using System.Collections;
using UnityEngine;

namespace EmotionQuest.SceneFlowModule
{
    public class GameplaySceneController : SceneController
    {
        [SerializeField] private GameplayController gameplayController;

        public override void Init(Action<bool> _callback = null) =>
            StartCoroutine(Wait(_callback));

        IEnumerator Wait(Action<bool> callback)
        {
            yield return new WaitForSeconds(2);
            gameplayController.Init();
            callback?.Invoke(true);
        }
    }
}
