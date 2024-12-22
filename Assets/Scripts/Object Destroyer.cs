using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    void Update()
    {
        if (transform.position.x < -15)
        {
            Destroy(gameObject);
        }
    }
}
