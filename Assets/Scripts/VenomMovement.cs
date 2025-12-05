using UnityEngine;

public class VenomMovement : MonoBehaviour
{
    public float slitherSpeed = 3f;
    public float poisonGlow = 2f;
    public Renderer venomRenderer;

    void Update()
    {
        Slither();
        Glow();
        RandomRotations();
    }

    void Slither()
    {
        transform.position += transform.forward * slitherSpeed * Time.deltaTime;
    }

    void Glow()
    {
        if (venomRenderer != null)
        {
            venomRenderer.material.color = Color.Lerp(
                Color.green, 
                Color.black,
                (Mathf.Sin(Time.time * poisonGlow) + 1) / 2f
            );
        }
    }

    void RandomRotations()
    {
        if (Random.value < 0.01f)
            transform.Rotate(Random.insideUnitSphere * 15f);
    }
}
