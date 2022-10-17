using System;
using System.Collections;
using UnityEngine;

namespace EmotionQuest.SceneFlowModule
{
    public class HomeSceneController : SceneController
    {
        public GameObject levelsPanel;
        public GameObject[] levelsButtons;

        public override void Init(Action<bool> _callback = null)
        {
            int levelesUnlocked = PlayerPrefs.GetInt("unlockedScenes", 1);

            for (int i = 0; i < levelesUnlocked; i++)
                levelsButtons[i].SetActive(true);

            StartCoroutine(Wait(_callback));
        }

        public void PlayButton() =>
            levelsPanel.SetActive(true);

        public void GoToScene(string name) =>
            SceneFlowManager.instance.LoadScene(name);

        IEnumerator Wait(Action<bool> callback)
        {
            yield return new WaitForSeconds(2);
            callback?.Invoke(true);
        }
    }
}
