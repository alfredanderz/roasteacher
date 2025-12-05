using UnityEngine;

public class FinalAward : MonoBehaviour
{
    public float rotationSpeed = 50f;
    public float floatAmplitude = 0.5f;
    public float floatSpeed = 2f;

    public Light shineLight;
    public float pulsingSpeed = 3f;
    public float minIntensity = 0.5f;
    public float maxIntensity = 2f;

    private float startY;

    void Start()
    {
        startY = transform.position.y;
    }

    void Update()
    {
        RotateAward();
        FloatAward();
        ShineEffect();
    }

    void RotateAward()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

    void FloatAward()
    {
        float newY = startY + Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    void ShineEffect()
    {
        if (shineLight == null) return;

        shineLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, (Mathf.Sin(Time.time * pulsingSpeed) + 1) / 2f);
    }
}
