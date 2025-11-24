using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void LateUpdate()
    {
        if (target == null) return;

        // Solo sigue en Z y Y (como Mario)
        Vector3 desiredPosition = new Vector3(
            transform.position.x,                      // X fijo
            target.position.y + offset.y,             // Sigue altura
            target.position.z + offset.z              // Sigue avance
        );

        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.LookAt(target);
    }
}
