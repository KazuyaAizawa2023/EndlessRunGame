using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public GameObject rockPrefab;    // 岩のプレハブ
    public float spawnInterval = 3.0f; // 岩の生成間隔（秒）
    public float spawnRadius = 5.0f;   // 岩の生成範囲

    private float timer = 0.0f;

    private void Update()
    {
        // 指定の間隔ごとに岩を生成
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnRock();
            timer = 0.0f;
        }
    }

    void SpawnRock()
    {
        // ランダムな位置に岩を生成
        Vector3 randomSpawnPoint = transform.position + Random.insideUnitSphere * spawnRadius;
        GameObject rock = Instantiate(rockPrefab, randomSpawnPoint, Quaternion.identity);
    }
}

