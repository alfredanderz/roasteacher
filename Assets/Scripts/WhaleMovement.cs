using UnityEngine;

public class WhaleMovement : MonoBehaviour
{
    public float swimSpeed = 1.5f;
    public float diveDepth = 20f;
    public float turnStrength = 2f;
    public bool bubbleMode = false;

    private float waveOffset;
    private float noiseTimer;

    void Start()
    {
        waveOffset = Random.Range(0f, 999f);
    }

    void Update()
    {
        SwimForward();
        ApplyWavePattern();
        RandomNoiseMovement();
        if (Input.GetKeyDown(KeyCode.B)) ToggleBubbleMode();
    }

    void SwimForward()
    {
        transform.position += transform.forward * swimSpeed * Time.deltaTime;
    }

    void ApplyWavePattern()
    {
        float verticalWave = Mathf.Sin(Time.time + waveOffset) * 0.2f;
        transform.position += new Vector3(0, verticalWave * Time.deltaTime, 0);
    }

    void RandomNoiseMovement()
    {
        noiseTimer += Time.deltaTime;
        if (noiseTimer > 2f)
        {
            noiseTimer = 0f;
            transform.Rotate(Random.insideUnitSphere * turnStrength);
        }
    }

    void ToggleBubbleMode()
    {
        bubbleMode = !bubbleMode;
    }
}
