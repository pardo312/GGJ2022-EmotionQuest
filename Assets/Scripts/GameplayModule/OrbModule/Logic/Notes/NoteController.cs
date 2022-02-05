using UnityEngine;

namespace EmotionQuest.GameplayModule.OrbModule
{
    public class NoteController : MonoBehaviour
    {
        [SerializeField] public OrbData orbData;

        private void OnBecameInvisible()
        {
            enabled = false;
        }

        private void OnBecameVisible()
        {
            enabled = true;
        }
    }
}
