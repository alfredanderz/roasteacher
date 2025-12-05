using UnityEngine;

public class SharkMovement : MonoBehaviour
{
    public float speed = 4f;
    public float aggressiveness = 1f;
    public Transform target;

    private float circlingTimer;

    void Update()
    {
        Swim();
        CircleAroundTarget();
        LookMenacing();
    }

    void Swim()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void CircleAroundTarget()
    {
        if (target == null) return;

        circlingTimer += Time.deltaTime * 0.5f;
        float radius = 5 + Mathf.Sin(circlingTimer) * 2;
        transform.RotateAround(target.position, Vector3.up, speed * Time.deltaTime);
    }

    void LookMenacing()
    {
        transform.localScale = Vector3.one * (1 + Mathf.Sin(Time.time * aggressiveness) * 0.1f);
    }
}
