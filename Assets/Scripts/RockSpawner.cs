using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public GameObject rockPrefab;    // ��̃v���n�u
    public float spawnInterval = 3.0f; // ��̐����Ԋu�i�b�j
    public float spawnRadius = 5.0f;   // ��̐����͈�

    private float timer = 0.0f;

    private void Update()
    {
        // �w��̊Ԋu���ƂɊ�𐶐�
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnRock();
            timer = 0.0f;
        }
    }

    void SpawnRock()
    {
        // �����_���Ȉʒu�Ɋ�𐶐�
        Vector3 randomSpawnPoint = transform.position + Random.insideUnitSphere * spawnRadius;
        GameObject rock = Instantiate(rockPrefab, randomSpawnPoint, Quaternion.identity);
    }
}

