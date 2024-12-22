using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("최소 스폰 시간 설정 값")]
    public float minSpawnDelay;

    [Tooltip("최대 스폰 시간 설정 값")]
    public float maxSpawnDelay;

    [Header("References")]
    [Tooltip("건물 프리팹")]
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
