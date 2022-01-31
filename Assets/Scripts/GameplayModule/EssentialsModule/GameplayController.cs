using EmotionQuest.GameplayModule.HealthModule;
using EmotionQuest.GameplayModule.OrbModule;
using EmotionQuest.InputModule;
using EmotionQuest.SceneFlowModule;
using Jiufen.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        public string songToPlay;
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
                AudioManager.PlayAudio(songToPlay, audioJobExtras);
            });
        }

        public void Death()
        {
            DesuscribeEvents();
            notesManager.EndGame();
            endGameController.EndGame(false);
            AudioManager.StopAudio(songToPlay);
        }


        public void ExitGameplay()
        {
            SceneFlowManager.instance.LoadScene("Home");
        }

        [ContextMenu("reset")]
        public void RestartGameplay()
        {
            SceneFlowManager.instance.LoadScene(SceneManager.GetActiveScene().name);
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