using UnityEngine;

namespace EmotionQuest.GameplayModule.OrbModule
{
    public class NotesManager : MonoBehaviour
    {
        [SerializeField] private float trackSpeed = 15;
        private bool isPlaying = false;

        public void Init() =>
            isPlaying = true;

        public void Update()
        {
            if(isPlaying)
                transform.position -= new Vector3(trackSpeed * 100 * Time.deltaTime, 0, 0);
        }

        public void EndGame() =>
            isPlaying = false;
    }
}
