using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("�̵� �ӵ�")]
    public float moveSpeed;
    void Update()
    {
        transform.position += Vector3.left * GameManager.Instance.CalculateGameSpeed() * Time.deltaTime;
        //transform.Translate(transform.position + Vector3.left * moveSpeed * Time.deltaTime);
    }
}
