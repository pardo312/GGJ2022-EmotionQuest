using System;
using UnityEngine;
using UnityEngine.UI;

namespace EmotionQuest.GameplayModule.OrbModule
{

    public class NotesManager : MonoBehaviour
    {
        private bool isPlaying = false;
        public float trackSpeed = 80;
        public void Init()
        {
            isPlaying = true;
        }

        public void Update()
        {
            if(isPlaying)
                transform.position -= new Vector3(trackSpeed * 100 *Time.deltaTime,0,0);
        }

    }
}
