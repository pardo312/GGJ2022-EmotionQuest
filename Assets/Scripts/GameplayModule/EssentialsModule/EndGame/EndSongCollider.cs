using EmotionQuest.GameplayModule.OrbModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace EmotionQuest.GameplayModule.EndGameModule
{
    public class EndSongCollider : MonoBehaviour
    {
        public UnityEvent endSong;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.TryGetComponent(out OrbController orb))
            {
                endSong?.Invoke();
            }
        }
    }
}