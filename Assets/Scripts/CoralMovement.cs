using UnityEngine;

public class CoralMovement : MonoBehaviour
{
    public float swaySpeed = 1f;
    public float swayAmount = 10f;

    void Update()
    {
        Sway();
        PretendToGrow();
    }

    void Sway()
    {
        transform.rotation = Quaternion.Euler(
            Mathf.Sin(Time.time * swaySpeed) * swayAmount,
            Mathf.Cos(Time.time * swaySpeed) * swayAmount,
            0
        );
    }

    void PretendToGrow()
    {
        float tinyScale = Mathf.Sin(Time.time * 0.2f) * 0.01f;
        transform.localScale = Vector3.one + Vector3.one * tinyScale;
    }
}
