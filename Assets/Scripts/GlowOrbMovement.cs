using UnityEngine;

public class GlowOrbMovement : MonoBehaviour
{
    public float rotateSpeed = 60f;
    public float glowSpeed = 4f;

    private Renderer r;

    void Start()
    {
        r = GetComponent<Renderer>();
    }

    void Update()
    {
        Rotate();
        Glow();
        Drifting();
    }

    void Rotate()
    {
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }

    void Glow()
    {
        float t = (Mathf.Sin(Time.time * glowSpeed) + 1) / 2f;
        r.material.color = Color.Lerp(Color.magenta, Color.white, t);
    }

    void Drifting()
    {
        transform.position += new Vector3(
            Mathf.Sin(Time.time) * 0.001f,
            Mathf.Cos(Time.time) * 0.001f,
            0
        );
    }
}
