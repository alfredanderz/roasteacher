using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    [Header("Movimiento Lineal")]
    public float moveSpeed = 1f;
    public float movementRange = 20f;

    [Header("Movimiento Ondulatorio")]
    public float waveAmplitude = 1f;
    public float waveSpeed = 1.5f;

    [Header("Efecto de Transparencia")]
    public bool enableFade = true;

    private Renderer rend;
    private Color originalColor;

    [Header("Ajustes de Deformación Opcional")]
    public bool enableDeformation = true;
    public float deformationAmount = 0.1f;
    public float deformationSpeed = 2f;
    private Vector3 initialScale;

    void Start()
    {
        rend = GetComponent<Renderer>();
        if (rend != null)
            originalColor = rend.material.color;

        initialScale = transform.localScale;
    }

    void Update()
    {
 
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;

 
        transform.position += new Vector3(
            0,
            Mathf.Sin(Time.time * waveSpeed) * waveAmplitude * Time.deltaTime,
            0
        );

        
        if (transform.position.x > movementRange)
            transform.position = new Vector3(-movementRange, transform.position.y, transform.position.z);

        
        if (enableFade && rend != null)
        {
            float fade = Mathf.PingPong(Time.time * 0.3f, 1);
            rend.material.color = Color.Lerp(
                originalColor,
                new Color(originalColor.r, originalColor.g, originalColor.b, 0.5f),
                fade
            );
        }

        
        if (enableDeformation)
        {
            float deformValue = Mathf.Sin(Time.time * deformationSpeed) * deformationAmount;
            transform.localScale = initialScale + new Vector3(deformValue, deformValue * 0.5f, 0);
        }
    }
}
