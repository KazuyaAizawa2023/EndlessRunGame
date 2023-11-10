using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public GameObject rockPrefab;    // 岩のプレハブ
    public float spawnInterval = 3.0f; // 岩の生成間隔（秒）
    public float initialDelay = 2.0f;  // 初期遅延時間

    private Camera mainCamera;
    private float timer = 0.0f;

    private void Start()
    {
        mainCamera = Camera.main; // カメラを取得

        // 最初の岩を生成
        SpawnRockDelayed(initialDelay);
    }

    private void Update()
    {
        timer += Time.deltaTime; // 経過時間を更新

        // 指定の間隔ごとに岩を生成
        if (timer >= spawnInterval)
        {
            SpawnRockDelayed(0.0f); // 岩を生成するメソッドを呼び出す（初期遅延なし）
            timer = 0.0f; // タイマーをリセット
        }
    }

    void SpawnRockDelayed(float delay)
    {
        // 指定の遅延時間後に岩を生成
        Invoke("SpawnRock", delay);
    }

    void SpawnRock()
    {
        // ランダムな位置を生成（画面内のランダムな位置を取得）
        Vector3 randomViewportPoint = new Vector3(Random.value, Random.Range(0.5f, 1.0f), 0); // Y座標を1.0fに設定して画面の上部に生成
        Vector3 randomWorldPoint = mainCamera.ViewportToWorldPoint(randomViewportPoint);

        // 岩を生成し、手前に配置
        GameObject rock = Instantiate(rockPrefab, randomWorldPoint, Quaternion.identity);
        rock.transform.position = new Vector3(rock.transform.position.x, rock.transform.position.y, 0); // Z座標を手前に配置

        // 生成された岩に RockMovement スクリプトをアタッチ
        rock.AddComponent<RockMovement>();
    }
}

