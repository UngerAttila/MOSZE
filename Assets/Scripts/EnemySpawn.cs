using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 3f;

    public Vector2 spawnAreaMin = new Vector2(-4, 0);
    public Vector2 spawnAreaMax = new Vector2(4, 4);

    private float spawnTimer;

    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            SpawnEnemy();
            spawnTimer = 0f;
        }
    }

    void SpawnEnemy()
    {
        Vector2 spawnPosition = new Vector2(
            Random.Range(spawnAreaMin.x, spawnAreaMax.x),
            Random.Range(spawnAreaMin.y, spawnAreaMax.y)
        );

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 topLeft = new Vector3(spawnAreaMin.x, spawnAreaMax.y, 0);
        Vector3 topRight = new Vector3(spawnAreaMax.x, spawnAreaMax.y, 0);
        Vector3 bottomRight = new Vector3(spawnAreaMax.x, spawnAreaMin.y, 0);
        Vector3 bottomLeft = new Vector3(spawnAreaMin.x, spawnAreaMin.y, 0);

        Gizmos.DrawLine(topLeft, topRight);
        Gizmos.DrawLine(topRight, bottomRight);
        Gizmos.DrawLine(bottomRight, bottomLeft);
        Gizmos.DrawLine(bottomLeft, topLeft);
    }
}

