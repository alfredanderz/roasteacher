using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    public float driftSpeed = 0.5f;
    public float fluffiness = 1f;

    void Update()
    {
        Drift();
        Fluff();
    }

    void Drift()
    {
        transform.position += Vector3.right * driftSpeed * Time.deltaTime;
    }

    void Fluff()
    {
        transform.localScale = Vector3.one * (1 + Mathf.Sin(Time.time * fluffiness) * 0.05f);
    }
}
