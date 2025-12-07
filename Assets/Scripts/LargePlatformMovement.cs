using System.Collections;
using UnityEngine;

public class LargePlatformMovement : MonoBehaviour
{
    [Header("Configuración de Movimiento")]
    public Vector3 startPoint;
    public Vector3 endPoint;
    public float movementSpeed = 2f;

    [Header("Efectos Adicionales")]
    public bool enableVibration = false;
    public float vibrationIntensity = 0.02f;
    public bool enableRotation = true;
    public float rotationSpeed = 20f;

    [Header("Control de Ciclos")]
    public bool waitAtLimits = true;
    public float waitDuration = 2f;
    private bool isWaiting = false;

    private float t = 0f;
    private bool forward = true;

    void Start()
    {
        startPoint = transform.position;
        endPoint = transform.position + new Vector3(10f, 0f, 0f);
    }

    void Update()
    {
        if (isWaiting) return;

        t += (forward ? 1 : -1) * Time.deltaTime * movementSpeed;
        t = Mathf.Clamp01(t);

        Vector3 basePosition = Vector3.Lerp(startPoint, endPoint, t);

        if (enableVibration)
            basePosition += new Vector3(Mathf.Sin(Time.time * 50f) * vibrationIntensity, 0, 0);

        transform.position = basePosition;

        if (enableRotation)
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        if (t >= 1f || t <= 0f)
        {
            if (waitAtLimits)
                StartCoroutine(WaitRoutine());
            else
                forward = !forward;
        }
    }

    IEnumerator WaitRoutine()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitDuration);
        forward = !forward;
        isWaiting = false;
    }
}
