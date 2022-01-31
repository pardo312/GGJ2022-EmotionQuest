using System;
using UnityEngine;

namespace EmotionQuest.SceneFlowModule
{
    public abstract class SceneController : MonoBehaviour
    {
        #region Singleton

        public static SceneController instance;

        protected virtual void Awake()
        {
            instance = this;
        }

        #endregion Singleton

        #region Methods

        public abstract void Init(Action<bool> _callback = null);

        #endregion Methods
    }
}