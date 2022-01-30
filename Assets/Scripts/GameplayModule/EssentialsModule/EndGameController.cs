using UnityEngine;

namespace EmotionQuest.GameplayModule
{
    public class EndGameController : MonoBehaviour
    {
        [SerializeField] private GameObject m_panelEndGame;
        [SerializeField] private EndGamePanelController m_panelWin;
        [SerializeField] private EndGamePanelController m_panelLose;

        public void EndGame(bool won)
        {
            m_panelEndGame.SetActive(true);
            if (won)
            {
                Debug.Log("YOU WIN");
                m_panelWin.ShowPanel();
            }
            else
            {
                Debug.Log("YOU LOSE");
                m_panelLose.ShowPanel();
            }
        }
    }
}