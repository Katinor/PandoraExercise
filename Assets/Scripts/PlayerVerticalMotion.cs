using UnityEngine;

public sealed class PlayerVerticalMotion : MonoBehaviour
{
    [SerializeField, Min(0f)] private float travelHeight = 3f;
    [SerializeField, Min(0f)] private float cyclesPerSecond = 8f;

    private Vector3 startPosition;
    private double phase;

    private void OnEnable()
    {
        startPosition = transform.localPosition;
        phase = 0d;
    }

    private void Update()
    {
        phase = (phase + Time.deltaTime * cyclesPerSecond) % 1d;

        float offset = travelHeight * 0.5f * (1f - Mathf.Cos((float)(phase * System.Math.PI * 2d)));
        transform.localPosition = startPosition + Vector3.up * offset;
    }

    private void OnDisable()
    {
        transform.localPosition = startPosition;
    }
}
