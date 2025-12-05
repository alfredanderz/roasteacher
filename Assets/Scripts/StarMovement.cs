using UnityEngine;

public class StarMovement : MonoBehaviour
{
    public float twinkleSpeed = 5f;
    public float rotateSpeed = 20f;

    void Update()
    {
        Twinkle();
        Rotate();
        RandomShift();
    }

    void Twinkle()
    {
        float b = (Mathf.Sin(Time.time * twinkleSpeed) + 1) / 2f;
        GetComponent<Renderer>().material.color = new Color(b, b, 1, 1);
    }

    void Rotate()
    {
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }

    void RandomShift()
    {
        if (Random.value < 0.002f)
            transform.position += Random.insideUnitSphere * 0.1f;
    }
}
