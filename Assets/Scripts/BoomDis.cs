using UnityEngine;

public class BoomDisappear : MonoBehaviour
{
    [Header("Settings")]
    public string targetTag = "Player";
    public float delayBeforeHide = 0f;

    [Header("Optional Effects")]
    public bool disableRenderer = true;
    public bool disableCollider = true;
    public bool playParticle = false;

    public ParticleSystem boomParticles;

    private Renderer[] renderers;
    private Collider[] colliders;
    private bool triggered = false;

    void Start()
    {
 
        renderers = GetComponentsInChildren<Renderer>();
        colliders = GetComponentsInChildren<Collider>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (triggered) return; // Evita ejecutar varias veces
        if (!other.CompareTag(targetTag)) return;

        triggered = true;

        if (playParticle && boomParticles != null)
            boomParticles.Play();

        Invoke(nameof(HideObject), delayBeforeHide);
    }

    void HideObject()
    {
        if (disableRenderer)
            foreach (var r in renderers)
                r.enabled = false;

        if (disableCollider)
            foreach (var c in colliders)
                c.enabled = false;
    }
}
