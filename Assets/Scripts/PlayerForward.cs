 
public class PlayerForward : MonoBehaviour
{
    [Header("Movement Settings")]
    public float forwardSpeed = 5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
         rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, forwardSpeed);
    }

     void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(horizontal * forwardSpeed, rb.velocity.y, rb.velocity.z);
    }
}
