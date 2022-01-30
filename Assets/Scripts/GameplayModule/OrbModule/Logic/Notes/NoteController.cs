using System;
using UnityEngine;
using UnityEngine.UI;

namespace EmotionQuest.GameplayModule.OrbModule
{
    public class NoteController : MonoBehaviour
    {
        private void OnBecameInvisible()
        {
            enabled = false;
        }

        private void OnBecameVisible()
        {
            enabled = true;
        }

        [SerializeField] public OrbData orbData;
    }
}
