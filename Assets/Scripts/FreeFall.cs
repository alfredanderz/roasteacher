using UnityEngine;

public class FreeFall : MonoBehaviour
{
    [Header("Detección de Caída")]
    public float fallLimit = -10f;

    [Header("Respawn")]
    public bool enableRespawn = true;
    public Vector3 respawnPoint;

    [Header("Audio")]
    public AudioClip fallSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (respawnPoint == Vector3.zero)
            respawnPoint = transform.position;
    }

    void Update()
    {
        if (transform.position.y < fallLimit)
        {
            if (audioSource && fallSound)
                audioSource.PlayOneShot(fallSound);

            if (enableRespawn)
                transform.position = respawnPoint;

            Debug.LogWarning("Jugador cayó fuera de los límites.");
        }
    }
}
