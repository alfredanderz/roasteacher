using UnityEngine;

public class Coin : MonoBehaviour
{
    // Velocidad de rotación en grados por segundo
    public float rotationSpeed = 180f;

    void Update()
    {
        // Gira alrededor del eje Y (puedes cambiarlo por X o Z)
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
