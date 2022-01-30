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
            if (testMode)
            {
                Init();
            }
        }

        #endregion Singleton

        public bool testMode;
        #region Methods

        public abstract void Init(Action<bool> _callback = null);

        #endregion Methods
    }
}