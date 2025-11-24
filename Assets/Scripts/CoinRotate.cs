using UnityEngine;

public class CoinRotate : MonoBehaviour
{
    [Header("Rotation Settings")]
    public float rotationSpeed = 150f;
    public bool rotateX = false;
    public bool rotateY = true;
    public bool rotateZ = false;

    [Header("Floating Effect")]
    public bool enableFloating = true;
    public float floatAmplitude = 0.2f;
    public float floatFrequency = 2f;

    private Vector3 startPos;
    private float randomOffset;

    void Start()
    {
        // Guardamos la posición inicial para el efecto de flotación
        startPos = transform.position;

        // Un pequeño offset random para que varias monedas no floten sincronizadas
        randomOffset = Random.Range(0f, 10f);
    }

    void Update()
    {
        RotateCoin();
        if (enableFloating)
            FloatCoin();
    }

    void RotateCoin()
    {
        // Calcula el vector de rotación según qué ejes estén activados
        float x = rotateX ? rotationSpeed * Time.deltaTime : 0f;
        float y = rotateY ? rotationSpeed * Time.deltaTime : 0f;
        float z = rotateZ ? rotationSpeed * Time.deltaTime : 0f;

        transform.Rotate(x, y, z);
    }

    void FloatCoin()
    {
        // Movimiento suave de subida y bajada
        float newY = startPos.y + Mathf.Sin((Time.time + randomOffset) * floatFrequency) * floatAmplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
