using EmotionQuest.GameplayModule.HealthModule;
using EmotionQuest.GameplayModule.OrbModule;
using EmotionQuest.InputModule;
using EmotionQuest.SceneFlowModule;
using Jiufen.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EmotionQuest.GameplayModule
{
    public class GameplayController : MonoBehaviour
    {
        [SerializeField] private InputController inputController;
        [SerializeField] private OrbsManager orbsManager;
        [SerializeField] private NotesManager notesManager;
        [SerializeField] private CounterController counterController;
        [SerializeField] private HealthController healthController;
        [SerializeField] private EndGameController endGameController;
        [SerializeField] private GuyWalkingAnimation guyWalkingAnimation;

        [SerializeField] private string songToPlay;

        public void Init()
        {
            counterController.StartCounter(() =>
            {
                orbsManager.Init();
                healthController.Init();
                notesManager.Init();
                guyWalkingAnimation.Init();

                //Init controllers
                inputController.growHappiness += orbsManager.GrowHapinness;
                inputController.growSadness += orbsManager.GrowSaddness;

                orbsManager.scoreNote += healthController.IncreaseResource;
                orbsManager.failNote += healthController.DecreaseResource;
                healthController.playerDead += Lose;

                AudioJobOptions audioJobExtras = new AudioJobOptions(fadeIn: new AudioFadeInfo(true, 1),delay:0.7f);
                AudioManager.PlayAudio(songToPlay, audioJobExtras);
            });
        }

        public void OnDestroy() =>
            DesuscribeEvents();

        private void DesuscribeEvents()
        {
            inputController.growHappiness -= orbsManager.GrowHapinness;
            inputController.growSadness -= orbsManager.GrowSaddness;

            orbsManager.scoreNote -= healthController.IncreaseResource;
            orbsManager.failNote -= healthController.DecreaseResource;
            healthController.playerDead -= Lose;
        }

        private void EndLevel()
        {
            DesuscribeEvents();
            AudioManager.StopAudio(songToPlay);
            notesManager.EndGame();
        }

        [ContextMenu("LoseLevel")]
        public void Lose()
        {
            EndLevel();
            endGameController.EndGame(false);
        }

        [ContextMenu("WinLevel")]
        public void Win()
        {
            EndLevel();
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
    }
}