using UnityEngine;
using UnityEngine.UI;

namespace EmotionQuest.GameplayModule
{
    public class EndGamePanelController : MonoBehaviour
    {
        [SerializeField] private Image LabelCover;
        [SerializeField] private Image buttonCover;

        public void ShowPanel()
        {
            this.gameObject.SetActive(true);
            Color labelCoverColor = LabelCover.color;
            LeanTween.value(1, 0, 4)
                .setOnUpdate((float value) =>
                {
                    LabelCover.color = new Color(labelCoverColor.r, labelCoverColor.g, labelCoverColor.b, value);
                })
                .setOnComplete(() =>
                {
                    if (buttonCover != null)
                    {
                        LeanTween.value(1, 0, 4).setOnUpdate((float value) =>
                           {
                               buttonCover.color = new Color(labelCoverColor.r, labelCoverColor.g, labelCoverColor.b, value);
                           });
                    }
                });
        }

    }
}
