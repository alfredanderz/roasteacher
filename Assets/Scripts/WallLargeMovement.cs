using UnityEngine;

public class WallLargeMovement : MonoBehaviour
{
    [Header("Movimiento Vertical")]
    public float movementHeight = 5f;
    public float movementSpeed = 1.5f;

    [Header("Efectos Visuales")]
    public bool enableShake = true;
    public float shakeIntensity = 0.1f;

    [Header("Parpadeo Opcional")]
    public bool enableBlink = false;
    public Color blinkColorA = Color.red;
    public Color blinkColorB = Color.white;
    public float blinkSpeed = 2f;

    private Vector3 initialPosition;
    private Renderer rend;
    private float timer = 0f;
    private bool movingUp = true;

    void Start()
    {
        initialPosition = transform.position;
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        timer += Time.deltaTime * movementSpeed * (movingUp ? 1 : -1);
        float verticalOffset = Mathf.PingPong(timer, movementHeight);

        transform.position = new Vector3(initialPosition.x, initialPosition.y + verticalOffset, initialPosition.z);

        if (enableShake)
            transform.position += new Vector3(Mathf.Sin(Time.time * 20f) * shakeIntensity, 0, 0);

        if (enableBlink && rend != null)
            rend.material.color = Color.Lerp(blinkColorA, blinkColorB, Mathf.PingPong(Time.time * blinkSpeed, 1));

        movingUp = !(verticalOffset >= movementHeight - 0.01f || verticalOffset <= 0.01f);
    }
}
