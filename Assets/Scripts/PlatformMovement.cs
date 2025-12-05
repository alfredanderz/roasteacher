using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public Vector3 pointA;
    public Vector3 pointB;
    public float speed = 2f;
    public bool loop = true;

    private float t;
    private bool forward = true;

    void Start()
    {
        transform.position = pointA;
    }

    void Update()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        if (forward)
        {
            t += Time.deltaTime * speed;
            if (t >= 1f)
            {
                t = 1f;
                if (!loop) enabled = false;
                forward = false;
            }
        }
        else
        {
            t -= Time.deltaTime * speed;
            if (t <= 0f)
            {
                t = 0f;
                forward = true;
            }
        }

        transform.position = Vector3.Lerp(pointA, pointB, t);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(pointA, 0.2f);
        Gizmos.DrawSphere(pointB, 0.2f);
        Gizmos.DrawLine(pointA, pointB);
    }
}
