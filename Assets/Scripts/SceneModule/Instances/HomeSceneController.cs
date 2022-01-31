using System;
using System.Collections;
using UnityEngine;

namespace EmotionQuest.SceneFlowModule
{
public class HomeSceneController : SceneController
    {
        #region ----Methods----
        public override void Init(Action<bool> _callback = null)
        {
            PlayerPrefs.GetInt("unlockedScenes");
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
