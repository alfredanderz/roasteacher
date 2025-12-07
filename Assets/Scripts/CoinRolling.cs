using UnityEngine;

public class CoinRolling : MonoBehaviour
{
    [Header("Rotación")]
    public float rotationSpeed = 180f;

    [Header("Flotación")]
    public float hoverAmount = 0.2f;
    public float hoverSpeed = 2f;

    [Header("Iluminación")]
    public bool enableGlow = true;
    public Light glowLight;
    public float glowMinIntensity = 0.5f;
    public float glowMaxIntensity = 2f;

    [Header("Escala Dinámica")]
    public bool enablePulse = true;
    public float pulseAmount = 0.05f;
    public float pulseSpeed = 3f;

    private Vector3 originalScale;
    private Vector3 initialPosition;

    void Start()
    {
        originalScale = transform.localScale;
        initialPosition = transform.position;

        if (enableGlow && glowLight == null)
            glowLight = gameObject.AddComponent<Light>();
    }

    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        transform.position = initialPosition + new Vector3(
            0, Mathf.Sin(Time.time * hoverSpeed) * hoverAmount, 0
        );

        if (enablePulse)
        {
            float p = Mathf.Sin(Time.time * pulseSpeed) * pulseAmount;
            transform.localScale = originalScale + Vector3.one * p;
        }

        if (enableGlow)
        {
            glowLight.intensity =
                Mathf.Lerp(glowMinIntensity, glowMaxIntensity, Mathf.PingPong(Time.time, 1));
        }
    }
}
