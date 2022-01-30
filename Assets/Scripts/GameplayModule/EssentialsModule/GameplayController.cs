using EmotionQuest.GameplayModule.HealthModule;
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
        public HealthController healthController;
        public EndGameController endGameController;
        #endregion ----Fields----

        #region ----Methods----
        public void Init()
        {
            counterController.StartCounter(() =>
            {
                orbsManager.Init();
                healthController.Init();
                notesManager.Init();

                //Init controllers
                inputController.growHappiness += orbsManager.GrowHapinness;
                inputController.growSadness += orbsManager.GrowSaddness;

                orbsManager.failNote += healthController.DecreaseResource;
                healthController.playerDead += Death;

                AudioJobOptions audioJobExtras = new AudioJobOptions(fadeIn: new AudioFadeInfo(true, 1));
                AudioManager.PlayAudio("OST_TEEN", audioJobExtras);
            });
        }

        public void Death()
        {
            Debug.Log("FINISH DEAD");
            DesuscribeEvents();
            notesManager.EndGame();
            endGameController.EndGame(false);
            AudioManager.StopAudio("OST_TEEN");
        }

        public void OnDestroy()
        {
            DesuscribeEvents();
        }

        private void DesuscribeEvents()
        {
            inputController.growHappiness -= orbsManager.GrowHapinness;
            inputController.growSadness -= orbsManager.GrowSaddness;

            orbsManager.failNote -= healthController.DecreaseResource;
            healthController.playerDead -= Death;
        }
        #endregion ----Methods----
    }
}