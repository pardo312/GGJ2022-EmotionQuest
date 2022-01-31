using System;
using System.Collections;
using UnityEngine;

namespace EmotionQuest.SceneFlowModule
{
    public class HomeSceneController : SceneController
    {
        #region ----Fields----
        public GameObject levelsPanel;
        public GameObject[] levelsButtons;
        #endregion ----Fields----

        #region ----Methods----
        public override void Init(Action<bool> _callback = null)
        {
            int levelesUnlocked = PlayerPrefs.GetInt("unlockedScenes", -1);
            if (levelesUnlocked == -1)
            {
                levelesUnlocked = 1;
                PlayerPrefs.SetInt("unlockedScenes", levelesUnlocked );
            }

            for (int i = 0; i < levelesUnlocked; i++)
            {
                levelsButtons[i].SetActive(true);
            }
            StartCoroutine(Wait(_callback));
        }
        public void PlayButton()
        {
            levelsPanel.SetActive(true);
        }

        public void GoToScene(string name)
        {
            Debug.Log("lol");
            SceneFlowManager.instance.LoadScene(name);
        }

        IEnumerator Wait(Action<bool> callback)
        {
            yield return new WaitForSeconds(2);
            callback?.Invoke(true);
        }
        #endregion ----Methods----
    }
}
