using UnityEngine;

public class Fishing : MonoBehaviour
{
    [Header("Configuración de Movimiento")]
    [SerializeField] private float velocidad = 2f;
    [SerializeField] private float distanciaAvance = 1f;
    [SerializeField] private float tiempoEspera = 0.5f;
    
    private Vector3 posicionInicial;
    private bool moviendose = false;

    void Start()
    {
        posicionInicial = transform.position;
        StartCoroutine(MovimientoPez());
    }

    System.Collections.IEnumerator MovimientoPez()
    {
        while (true)
        {
            // 1. Avanzar poquito
            yield return StartCoroutine(Avanzar(distanciaAvance * 0.3f));
            yield return new WaitForSeconds(tiempoEspera);

            // 2. Girar aleatoriamente (izquierda o derecha)
            float anguloGiro = Random.Range(0, 2) == 0 ? -45f : 45f;
            yield return StartCoroutine(Girar(anguloGiro));
            yield return new WaitForSeconds(tiempoEspera);

            // 3. Avanzar poquito
            yield return StartCoroutine(Avanzar(distanciaAvance * 0.4f));
            yield return new WaitForSeconds(tiempoEspera);

            // 4. Retroceder
            yield return StartCoroutine(Avanzar(-distanciaAvance * 0.3f));
            yield return new WaitForSeconds(tiempoEspera);

            // 5. Avanzar poquito
            yield return StartCoroutine(Avanzar(distanciaAvance * 0.5f));
            yield return new WaitForSeconds(tiempoEspera * 2);
        }
    }

    System.Collections.IEnumerator Avanzar(float distancia)
    {
        moviendose = true;
        Vector3 posicionObjetivo = transform.position + transform.forward * distancia;
        
        while (Vector3.Distance(transform.position, posicionObjetivo) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, posicionObjetivo, velocidad * Time.deltaTime);
            yield return null;
        }
        
        moviendose = false;
    }

    System.Collections.IEnumerator Girar(float angulo)
    {
        moviendose = true;
        Quaternion rotacionObjetivo = transform.rotation * Quaternion.Euler(0, angulo, 0);
        
        while (Quaternion.Angle(transform.rotation, rotacionObjetivo) > 0.1f)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotacionObjetivo, velocidad * 50f * Time.deltaTime);
            yield return null;
        }
        
        moviendose = false;
    }
}