using UnityEngine;

public class GuyWalkingAnimation : MonoBehaviour
{
    [SerializeField] private Transform positionStart;
    [SerializeField] private Transform positionEnd;
    [SerializeField] private float animDuration;

    private float currentTime;
    private bool enableAnim;

    private void Start()
    {
        Enable();
    }

    private void Update()
    {
        if (enableAnim && currentTime < animDuration)
            currentTime += Time.deltaTime;

        float normalizedTime = currentTime / animDuration;
        transform.position = Vector3.Lerp(positionStart.position, positionEnd.position, normalizedTime);
    }

    public void Enable() => enableAnim = true;
}
