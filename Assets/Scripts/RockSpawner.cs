using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public GameObject rockPrefab;    // 岩のプレハブ
    public float spawnInterval = 3.0f; // 岩の生成間隔（秒）

    private Camera mainCamera;
    private float timer = 0.0f;

    private void Start()
    {
        mainCamera = Camera.main; // カメラを取得
    }

    private void Update()
    {
        timer += Time.deltaTime; // 経過時間を更新

        // 指定の間隔ごとに岩を生成
        if (timer >= spawnInterval)
        {
            SpawnRock(); // 岩を生成するメソッドを呼び出す
            timer = 0.0f; // タイマーをリセット
        }
    }

    void SpawnRock()
    {
        // ランダムな位置を生成（画面内のランダムな位置を取得）
        Vector3 randomViewportPoint = new Vector3(Random.value, Random.value, 0);
        Vector3 randomWorldPoint = mainCamera.ViewportToWorldPoint(randomViewportPoint);

        // 岩を生成し、手前に配置
        GameObject rock = Instantiate(rockPrefab, randomWorldPoint, Quaternion.identity);
        rock.transform.position = new Vector3(rock.transform.position.x, rock.transform.position.y, 0); // Z座標を手前に配置
    }
}
