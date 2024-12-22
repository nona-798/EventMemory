using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("�ּ� ���� �ð� ���� ��")]
    public float minSpawnDelay;

    [Tooltip("�ִ� ���� �ð� ���� ��")]
    public float maxSpawnDelay;

    [Header("References")]
    [Tooltip("�ǹ� ������")]
    public GameObject[] objects;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        Invoke("Spawn", Random.RandomRange(minSpawnDelay,maxSpawnDelay));
    }
    private void OnDisable()
    {
        CancelInvoke();
    }
    void Spawn()
    {
        GameObject randomObject = objects[Random.Range(0, objects.Length)];
        Instantiate(randomObject, transform.position, Quaternion.identity);
        Invoke("Spawn", Random.RandomRange(minSpawnDelay, maxSpawnDelay));
    }
}
