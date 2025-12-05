using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    [Header("Velocidad y Movimiento")]
    public float baseSpeed = 2f;               
    public float acceleration = 0.5f;           
    public float maxSpeed = 5f;                 
    private float currentSpeed;                

    [Header("Ondulación del cuerpo")]
    public float waveAmplitude = 0.2f;         
    public float waveFrequency = 4f;           

    [Header("Giros y dirección")]
    public float turnSpeed = 2f;               
    public float randomTurnInterval = 3f;      
    private Vector3 targetDirection;           

    [Header("Rango de movimiento")]
    public bool usarLimites = false;
    public Vector3 limiteMin;                   
    public Vector3 limiteMax;                   

    private float waveTimer = 0f;
    private float nextRandomTurn = 0f;

    void Start()
    {
         targetDirection = transform.forward;
        currentSpeed = baseSpeed;
    }

    void Update()
    {
        SimularOndulacion();
        MoverPez();
        ControlarDireccionAleatoria();
        MantenerDentroDeLimites();
    }

       void SimularOndulacion()
    {
        waveTimer += Time.deltaTime * waveFrequency;

         float waveOffset = Mathf.Sin(waveTimer) * waveAmplitude;

         transform.localRotation = Quaternion.Euler(
            transform.localEulerAngles.x,
            transform.localEulerAngles.y,
            waveOffset * 20f
        );
    }

      void MoverPez()
    {
         currentSpeed = Mathf.Lerp(currentSpeed, baseSpeed, Time.deltaTime * acceleration);
        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);

         transform.position += transform.forward * currentSpeed * Time.deltaTime;
    }

       void ControlarDireccionAleatoria()
    {
         if (Time.time > nextRandomTurn)
        {
            nextRandomTurn = Time.time + Random.Range(1f, randomTurnInterval);

             Vector3 randomDir = new Vector3(
                Random.Range(-1f, 1f),
                Random.Range(-0.5f, 0.5f),
                Random.Range(-1f, 1f)
            ).normalized;

            targetDirection = randomDir;
        }

         if (targetDirection != Vector3.zero)
        {
            Quaternion targetRot = Quaternion.LookRotation(targetDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRot,
                Time.deltaTime * turnSpeed
            );
        }
    }

     void MantenerDentroDeLimites()
    {
        if (!usarLimites) return;

        Vector3 pos = transform.position;
        bool fuera = false;

        if (pos.x < limiteMin.x) { pos.x = limiteMin.x; fuera = true; }
        if (pos.y < limiteMin.y) { pos.y = limiteMin.y; fuera = true; }
        if (pos.z < limiteMin.z) { pos.z = limiteMin.z; fuera = true; }

        if (pos.x > limiteMax.x) { pos.x = limiteMax.x; fuera = true; }
        if (pos.y > limiteMax.y) { pos.y = limiteMax.y; fuera = true; }
        if (pos.z > limiteMax.z) { pos.z = limiteMax.z; fuera = true; }

        if (fuera)
        {
             Vector3 centro = (limiteMin + limiteMax) / 2f;
            targetDirection = (centro - transform.position).normalized;
        }

        transform.position = pos;
    }
}
