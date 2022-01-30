using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EmotionQuest.SceneFlowModule
{
    public class RotateLoading : MonoBehaviour
    {
        void Update()
        {
            transform.Rotate(new Vector3(0, 0, -5f));
        }
    }
}