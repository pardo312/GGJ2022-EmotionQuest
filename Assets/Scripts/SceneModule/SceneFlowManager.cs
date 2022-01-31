using UnityEngine;
using UnityEngine.SceneManagement;

namespace EmotionQuest.SceneFlowModule
{
    public class SceneFlowManager : MonoBehaviour
    {
        #region ----Singleton----
        public static SceneFlowManager instance;

        private void Awake()
        {
            if (instance != null)
            {
                DestroyImmediate(this);
                return;
            }

            instance = this;
            DontDestroyOnLoad(this);
        }
        #endregion ----Singleton----

        #region ----Fields----
        [SerializeField] private string nameOfLoadingScene;
        private string previousScene;
        #endregion ----Fields----

        #region ----Methods----
        public void Start()
        {
            previousScene = SceneManager.GetActiveScene().name;
            SceneController.instance.Init();
        }
        [ContextMenu("test")]
        public void Test()
        {
            LoadScene("Gameplay");
        }
        public void LoadScene(string name)
        {
            SceneManager.LoadSceneAsync(nameOfLoadingScene, LoadSceneMode.Additive).completed += (operation) =>
            {
                SceneManager.UnloadSceneAsync(previousScene);
            };
            SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive).completed += (operation) =>
             {
                 SceneController.instance.Init((loadSuccess) => SceneLoaded(loadSuccess, name));
             };
        }

        private void SceneLoaded(bool loadSuccess, string nameOfSceneLoaded)
        {
            if (loadSuccess)
            {
                SceneManager.UnloadSceneAsync(nameOfLoadingScene);
                previousScene = nameOfSceneLoaded;
            }
            else
            {
                SceneManager.UnloadSceneAsync(nameOfSceneLoaded).completed += (operation) =>
                 {
                     SceneManager.LoadSceneAsync(previousScene, LoadSceneMode.Additive);
                     SceneManager.UnloadSceneAsync(nameOfLoadingScene);
                 };
            }
        }
        #endregion ----Methods----
    }
}
