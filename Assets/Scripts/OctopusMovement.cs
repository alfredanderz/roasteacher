using UnityEngine;

public class OctopusMovement : MonoBehaviour
{
    public float wobbleIntensity = 0.5f;
    public float speed = 1f;

    private Vector3 wobbleOffset;

    void Start()
    {
        wobbleOffset = new Vector3(Random.value, Random.value, Random.value);
    }

    void Update()
    {
        Wiggle();
        FloatAround();
        RandomInkBurst();
    }

    void Wiggle()
    {
        transform.localScale = Vector3.one + new Vector3(
            Mathf.Sin(Time.time * 3f) * wobbleIntensity,
            Mathf.Cos(Time.time * 2f) * wobbleIntensity,
            Mathf.Sin(Time.time * 4f) * wobbleIntensity
        ) * 0.1f;
    }

    void FloatAround()
    {
        transform.position += (transform.forward + wobbleOffset) * speed * Time.deltaTime;
    }

    void RandomInkBurst()
    {
        if (Random.value < 0.005f)
            Debug.Log("SPLAT! Ink burst.");
    }
}
