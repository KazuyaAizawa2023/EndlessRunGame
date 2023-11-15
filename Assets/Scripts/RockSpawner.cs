using System.Collections;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public GameObject rockPrefab;    // 岩のプレハブ
    public float spawnInterval = 3.0f; // 岩の生成間隔（秒）
    public float initialDelay = 2.0f;  // 初期遅延時間

    
    private Camera mainCamera;

    private void Start()
    {
        Camera foundCamera = Camera.main;
        if (foundCamera == null)
        {
            Debug.LogError("メインカメラが見つかりませんでした。");
        }
        else
        {
            Debug.Log("メインカメラが見つかりました: " + foundCamera.name);
        }

        mainCamera = foundCamera; // カメラを取得
        // Coroutineを開始
        StartCoroutine(SpawnRocksCoroutine());
    }

    private IEnumerator SpawnRocksCoroutine()
    {
        // 初期遅延
        yield return new WaitForSeconds(initialDelay);

        while (true)
        {
            // ランダムな位置を生成（画面の上半分のランダムな位置を取得）
            Vector3 randomViewportPoint = new Vector3(Random.value, Random.Range(0.5f, 1.0f), 0);
            Vector3 randomWorldPoint = mainCamera.ViewportToWorldPoint(randomViewportPoint);

            // 岩を生成し、手前に配置
            GameObject rock = Instantiate(rockPrefab, randomWorldPoint, Quaternion.identity);
            rock.transform.position = new Vector3(rock.transform.position.x, rock.transform.position.y, 0); // Z座標を手前に配置

            // 生成された岩に RockMovement スクリプトをアタッチ
            rock.AddComponent<RockMovement>();

            // デバッグログで生成された岩の位置情報を表示
            Debug.Log("岩が生成されました。位置: " + randomWorldPoint);

            // 指定の間隔だけ待機
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}

