using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void LateUpdate()
    {
        if (target == null) return;

        // Posición suavizada
        Vector3 desiredPosition = new Vector3(
            transform.position.x,
            target.position.y + offset.y,
            target.position.z + offset.z
        );

        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Rotación fija
        transform.rotation = Quaternion.Euler(20f, 0f, 0f);
    }
}
