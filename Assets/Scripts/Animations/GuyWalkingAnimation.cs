using UnityEngine;

namespace EmotionQuest.GameplayModule
{
    public class GuyWalkingAnimation : MonoBehaviour
    {
        [SerializeField] private Transform positionStart;
        [SerializeField] private Transform positionEnd;
        [SerializeField] private float animDuration;

        private float currentTime;
        private bool enableAnim;

        public void Init() =>
            enableAnim = true;

        private void Update()
        {
            if (enableAnim && currentTime < animDuration)
                currentTime += Time.deltaTime;

            float normalizedTime = currentTime / animDuration;
            transform.position = Vector3.Lerp(positionStart.position, positionEnd.position, normalizedTime);
        }
    }
}
