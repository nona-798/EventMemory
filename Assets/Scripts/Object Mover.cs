using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("이동 속도")]
    public float moveSpeed;
    void Update()
    {
        transform.position += Vector3.left * GameManager.Instance.CalculateGameSpeed() * Time.deltaTime;
        //transform.Translate(transform.position + Vector3.left * moveSpeed * Time.deltaTime);
    }
}
