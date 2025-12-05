using UnityEngine;

public class DragonMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float walkSpeed = 5f;
    public float flightSpeed = 12f;
    public float turnSpeed = 3f;

    [Header("Flight Settings")]
    public bool isFlying = false;
    public float wingFlapForce = 10f;
    public float hoverHeight = 5f;

    [Header("FX")]
    public ParticleSystem fireBreathFX;
    public AudioSource roarSFX;

    private Rigidbody rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        HandleInput();
        UpdateAnimations();
    }

    void FixedUpdate()
    {
        if (isFlying) HandleFlightMovement();
        else HandleGroundMovement();
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.F))
            ToggleFly();

        if (Input.GetKeyDown(KeyCode.R))
            Roar();

        if (Input.GetKeyDown(KeyCode.Mouse0))
            BreathFire();
    }

    void HandleGroundMovement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = transform.forward * v * walkSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + move);

        transform.Rotate(Vector3.up * h * turnSpeed);
    }

    void HandleFlightMovement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 climb = Vector3.up * Mathf.Sin(Time.time) * 0.5f;

        Vector3 movement =
            (transform.forward * v + transform.right * h + climb)
            * flightSpeed * Time.fixedDeltaTime;

        rb.MovePosition(rb.position + movement);
    }

    void ToggleFly()
    {
        isFlying = !isFlying;
        rb.useGravity = !isFlying;

        if (isFlying) animator.SetTrigger("FlyStart");
        else animator.SetTrigger("FlyEnd");
    }

    void Roar()
    {
        if (roarSFX) roarSFX.Play();
        animator.SetTrigger("Roar");
    }

    void BreathFire()
    {
        if (fireBreathFX) fireBreathFX.Play();
        animator.SetTrigger("Fire");
    }

    void UpdateAnimations()
    {
        animator.SetBool("IsFlying", isFlying);
    }
}
