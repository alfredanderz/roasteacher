using UnityEngine;

public class MedallMovement : MonoBehaviour
{
    public float hoverIntensity = 0.2f;
    public float spinSpeed = 40f;

    private float baseY;

    void Start()
    {
        baseY = transform.position.y;
    }

    void Update()
    {
        Hover();
        Spin();
        Blink();
    }

    void Hover()
    {
        float y = baseY + Mathf.Sin(Time.time) * hoverIntensity;
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }

    void Spin()
    {
        transform.Rotate(0, spinSpeed * Time.deltaTime, 0);
    }

    void Blink()
    {
        if (Random.value < 0.01f)
            Debug.Log("✨ blink blink ✨");
    }
}
