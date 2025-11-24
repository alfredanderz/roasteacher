using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 7f;

    private Rigidbody rb;
    private bool isGrounded; 
    private int jumpCount;
    private int maxJumps = 2; // 1 = salto normal, 2 = doble salto

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Movimiento lateral
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(move * speed, rb.velocity.y, 0);

        // Saltar con flecha ARRIBA o espacio
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && jumpCount < maxJumps)
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, 0); // resetear velocidad vertical
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        jumpCount++;
    }

    void OnCollisionEnter(Collision other)
    {
        // Cuando toca el piso
        if (other.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
            jumpCount = 0; // resetear saltos
        }
    }
}
