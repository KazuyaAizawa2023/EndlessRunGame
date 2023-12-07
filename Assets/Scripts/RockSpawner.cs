using System.Collections;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public GameObject rockPrefab;    // 岩のプレハブ
    public float spawnInterval = 2.4f; // 岩の生成間隔（秒）
    public float initialDelay = 5.0f;  // 初期遅延時間
    private bool isCoroutineRunning = false;// コルーチンが実行中かどうかを示すフラグ


    private Camera mainCamera;

    //Start メソッド内で isCoroutineRunning の確認を行い、
    //Coroutine が既に開始されている場合は新たに開始しないようにする
    //これにより、複数の Coroutine が同時に実行されることを防ぐ

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
        // Coroutineが既に実行中でなければ開始
        if (!isCoroutineRunning)
        {
            StartCoroutine(SpawnRocksCoroutine());
        }
    }

    private IEnumerator SpawnRocksCoroutine()
    {
        Debug.Log("SpawnRocksCoroutine 開始");

        // 既にコルーチンが実行中である場合は再開させない
        if (isCoroutineRunning)
        {
            yield break;
        }

        isCoroutineRunning = true;

        yield return new WaitForSeconds(2.4f);


        while (true)
        {
            // ランダムな位置を生成（画面の上半分のランダムな位置を取得）
            Vector3 randomViewportPoint = new Vector3(Random.Range(0.0f, 1.0f), Random.Range(0.5f, 1.0f), 0);
            Vector3 randomWorldPoint = mainCamera.ViewportToWorldPoint(randomViewportPoint);

            // X座標を0.1だけ狭くする
            randomWorldPoint.x = Mathf.Clamp(randomWorldPoint.x, mainCamera.ViewportToWorldPoint(new Vector3(0.3f, 0, 0)).x, mainCamera.ViewportToWorldPoint(new Vector3(0.85f, 0, 0)).x);

            // 岩を生成し、手前に配置
            GameObject rock = Instantiate(rockPrefab, randomWorldPoint, Quaternion.identity);
            rock.transform.position = new Vector3(rock.transform.position.x, rock.transform.position.y, 0); // Z座標を手前に配置

            // 生成された岩に RockMovement スクリプトをアタッチ
            //rock.AddComponent<RockMovement>();

            // デバッグログで生成された岩の位置情報を表示
            Debug.Log("岩が生成されました。位置: " + randomWorldPoint);

            // 指定の間隔だけ待機
            yield return new WaitForSeconds(spawnInterval);
        }
        // コルーチンが終了したことをマーク
        isCoroutineRunning = false;
    }

    private void Update()
    {
        GameObject[] rocks = GameObject.FindGameObjectsWithTag("Rock"); // "Rock" タグのついたすべての岩を取得

        foreach (var rock in rocks)
        {
            if (rock.transform.position.y < mainCamera.ViewportToWorldPoint(Vector3.zero).y)
            {
                Destroy(rock); // 画面外に出たら削除
            }
        }
    }
}

