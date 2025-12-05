using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float countdown = 3f;
    public float explosionRadius = 5f;
    public float explosionForce = 800f;
    public ParticleSystem explosionFX;
    public Light warningLight;
    public AudioSource beepSound;
    public AudioSource explosionSound;
    private bool exploded = false;
    private float timer;
    private Vector3 originalScale;
    private float pulseSpeed = 6f;
    private float pulseAmount = 0.1f;

    void Start()
    {
        timer = countdown;
        originalScale = transform.localScale;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        float pulse = Mathf.Sin(Time.time * pulseSpeed) * pulseAmount;
        transform.localScale = originalScale + Vector3.one * pulse;

        if (warningLight)
        {
            warningLight.intensity = Mathf.PingPong(Time.time * 8f, 2f);
        }

        if (timer <= 1f && beepSound && !beepSound.isPlaying)
        {
            beepSound.Play();
        }

        if (timer <= 0f && !exploded)
        {
            Explode();
        }
    }

    void Explode()
    {
        exploded = true;

        if (explosionFX)
        {
            Instantiate(explosionFX, transform.position, Quaternion.identity);
        }

        if (explosionSound)
        {
            explosionSound.Play();
        }

        Collider[] cols = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider c in cols)
        {
            Rigidbody rb = c.GetComponent<Rigidbody>();
            if (rb)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, 0.5f, ForceMode.Impulse);
            }
        }

        transform.localScale = Vector3.zero;
        Destroy(gameObject, 0.1f);
    }
}
