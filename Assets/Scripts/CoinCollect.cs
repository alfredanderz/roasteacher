using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    [Header("Rotation Settings")]
    public float rotationSpeed = 180f;

    [Header("Collection Settings")]
    public string playerTag = "Player";

    private Renderer[] renderers;
    private Collider coinCollider;
    private Transform monedaTransform;
    private bool collected = false;

    void Start()
    {
        // Si tiene hijos, rota el hijo. Si no, rota el mismo objeto
        if (transform.childCount > 0)
        {
            monedaTransform = transform.GetChild(0);
        }
        else
        {
            monedaTransform = transform;
        }
        
        renderers = GetComponentsInChildren<Renderer>();
        coinCollider = GetComponent<Collider>();
        
        // Si no tiene collider, lo agregamos automáticamente
        if (coinCollider == null)
        {
            coinCollider = gameObject.AddComponent<SphereCollider>();
            coinCollider.isTrigger = true;
        }
    }

    void Update()
    {
        // Rota hacia la derecha (eje Y positivo, como Subway Surfers)
        if (monedaTransform != null)
        {
            monedaTransform.Rotate(0, rotationSpeed * Time.deltaTime, 0, Space.World);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger detectado con: " + other.gameObject.name + " Tag: " + other.tag);
        
        if (!other.CompareTag(playerTag) && !other.transform.root.CompareTag(playerTag))
        {
            return;
        }

        if (collected) return;

        collected = true;

        // Suma 1 al contador de monedas
        if (CoinManager.instance != null)
        {
            CoinManager.instance.AddCoin();
        }

        // Desaparece visualmente (se hace invisible)
        foreach (var r in renderers)
            r.enabled = false;

        // Desactiva el collider para que no se pueda recoger de nuevo
        coinCollider.enabled = false;

        // Destruye el objeto después de 0.1 segundos
        Destroy(gameObject, 0.1f);
    }
}

// ========================================
// COIN MANAGER - Pon este script en un GameObject vacío llamado "GameManager"
// ========================================

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;

    [Header("Coin Counter")]
    public int totalCoins = 0;

    void Awake()
    {
        // Singleton para que solo haya un CoinManager
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddCoin()
    {
        totalCoins++;
        Debug.Log("Monedas recogidas: " + totalCoins);
    }

    public int GetTotalCoins()
    {
        return totalCoins;
    }

    public void ResetCoins()
    {
        totalCoins = 0;
    }
}