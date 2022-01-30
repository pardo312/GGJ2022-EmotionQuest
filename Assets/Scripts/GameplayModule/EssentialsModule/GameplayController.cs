using EmotionQuest.GameplayModule.OrbModule;
using EmotionQuest.InputModule;
using Jiufen.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EmotionQuest.GameplayModule
{
    public class GameplayController : MonoBehaviour
    {

        #region ----Fields----
        public InputController inputController;
        public OrbsManager orbsManager;
        public NotesManager notesManager;
        public CounterController counterController;
        #endregion ----Fields----

        #region ----Methods----
        public void Init()
        {
            counterController.StartCounter(() =>
            {

                AudioJobOptions audioJobExtras = new AudioJobOptions(fadeIn:new AudioFadeInfo(true, 1));
                AudioManager.PlayAudio("OST_TEEN", audioJobExtras);

                notesManager.Init();
                //Init controllers
                inputController.growHappiness += orbsManager.GrowHapinness;
                inputController.growSadness += orbsManager.GrowSaddness;
            });
        }

        public void OnDestroy()
        {
            inputController.growHappiness -= orbsManager.GrowHapinness;
            inputController.growSadness -= orbsManager.GrowSaddness;
        }
        #endregion ----Methods----
    }
}