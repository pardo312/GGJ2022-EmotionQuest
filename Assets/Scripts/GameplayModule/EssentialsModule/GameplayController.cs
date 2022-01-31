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

                AudioJobOptions audioJobExtras = new AudioJobOptions(fadeIn: new AudioFadeInfo(true, 1),delay:0.7f);
                AudioManager.PlayAudio(songToPlay, audioJobExtras);
            });
        }

        public void Death()
        {
            DesuscribeEvents();
            AudioManager.StopAudio(songToPlay);
            notesManager.EndGame();
            endGameController.EndGame(false);
        }

        public void EndLevel()
        {
            endGameController.EndGame(true);
        }

        public void BackFromSuccesfulLevel()
        {
            int currentLevelUnlocked = PlayerPrefs.GetInt("unlockedScenes", 1);
            ++currentLevelUnlocked;
            if (currentLevelUnlocked <= 3)
                PlayerPrefs.SetInt("unlockedScenes", currentLevelUnlocked);
            ExitGameplay();
        }

        public void ExitGameplay()
        {
            AudioManager.StopAudio(songToPlay);
            SceneFlowManager.instance.LoadScene("Home");
        }

        [ContextMenu("reset")]
        public void RestartGameplay()
        {
            AudioManager.StopAudio(songToPlay);
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