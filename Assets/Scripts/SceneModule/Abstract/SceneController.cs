using System;
using UnityEngine;

namespace EmotionQuest.SceneFlowModule
{
    public abstract class SceneController : MonoBehaviour
    {
        public static SceneController instance;

        protected virtual void Awake() =>
            instance = this;

        public abstract void Init(Action<bool> _callback = null);
    }
}
