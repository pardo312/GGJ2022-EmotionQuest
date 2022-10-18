using UnityEngine;
using UnityEngine.UI;

namespace EmotionQuest.GameplayModule.OrbModule
{
    public class NotesManager : MonoBehaviour
    {
        [SerializeField] private float trackSpeed = 15;

        private CanvasScaler canvasScaler;
        private bool isPlaying = false;

        public void Init() =>
            isPlaying = true;

        private void Awake() =>
            canvasScaler = GetComponentInParent<CanvasScaler>();

        private void Update()
        {
            if(isPlaying)
                transform.position -= new Vector3(trackSpeed * 100 * Time.deltaTime * Screen.width / canvasScaler.referenceResolution.x, 0, 0);
        }

        public void EndGame() =>
            isPlaying = false;
    }
}
