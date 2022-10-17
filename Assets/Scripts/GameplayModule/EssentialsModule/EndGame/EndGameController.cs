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
                m_panelWin.ShowPanel();
            else
                m_panelLose.ShowPanel();
        }
    }
}
