using UnityEngine;

public class FisherDeep : MonoBehaviour
{
    public float swimSpeed = 2f;
    public float turnSpeed = 2f;

    public float wanderRadius = 5f;
    public float changeDirTime = 3f;

    private Vector3 targetDir;
    private float timer;

    void Start()
    {
        ChooseNewDirection();
    }

    void Update()
    {
        Swim();
        HandleDirectionChange();
    }

    void Swim()
    {
        transform.position += transform.forward * swimSpeed * Time.deltaTime;

        Quaternion targetRot = Quaternion.LookRotation(targetDir);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, turnSpeed * Time.deltaTime);
    }

    void HandleDirectionChange()
    {
        timer += Time.deltaTime;
        if (timer >= changeDirTime)
        {
            timer = 0f;
            ChooseNewDirection();
        }
    }

    void ChooseNewDirection()
    {
        Vector3 random = Random.insideUnitSphere * wanderRadius;
        random.y = Mathf.Clamp(random.y, -1f, 1f);
        targetDir = random.normalized;
    }
}
