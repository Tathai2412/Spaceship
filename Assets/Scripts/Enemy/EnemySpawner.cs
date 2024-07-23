using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private float minTime;
    [SerializeField]
    private float maxTime;
    
    private float spawnTime;
    
    void Awake()
    {
        SetSpawnTime();
    }

    void Update()
    {
        Spawn();
    }

    private void SetSpawnTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
    }

    private void Spawn()
    {
        spawnTime -= Time.deltaTime;

        if (spawnTime <= 0)
        {
            Instantiate(enemyPrefab, new Vector3(7.87f, Random.Range(-4.2f, 4.2f)), transform.rotation);
            SetSpawnTime();
        }
    }
}
