using EmotionQuest.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EmotionQuest.GameplayModule
{
    public class GameplayController : MonoBehaviour
    {

        #region ----Fields----
        public InputController inputController;
        public SpiritController spiritController;
        #endregion ----Fields----

        #region ----Methods----
        public void Init()
        {
            //SceneFlowModule.SceneFlowManager.instance.lol();
            //Init controllers
            inputController.growHappiness += spiritController.GrowHapinness;
            inputController.growSadness += spiritController.GrowSaddness;
        }

        public void OnDestroy()
        {
            inputController.growHappiness -= spiritController.GrowHapinness;
            inputController.growSadness -= spiritController.GrowSaddness;
        }
        #endregion ----Methods----
    }
}