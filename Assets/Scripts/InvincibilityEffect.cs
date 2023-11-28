using System.Collections;
using UnityEngine;

public class InvincibilityEffect : MonoBehaviour
{
    // メンバ変数の宣言
    private Renderer renderer; // オブジェクトの表示（色や形など）を管理するコンポーネント
    private Collider collider; // オブジェクトの当たり判定を管理するコンポーネント

    // 点滅の間隔と点滅後の非表示時間を定義
    private const float BlinkInterval = 0.15f;
    private const float PostBlinkDelay = 0.3f;

    // オブジェクトが作成されたときに呼ばれるメソッド
    void Start()
    {
        // オブジェクトにアタッチされたColliderコンポーネントを取得し、変数に格納
        collider = GetComponent<Collider>();
        // オブジェクトにアタッチされたRendererコンポーネントを取得し、変数に格納
        renderer = GetComponent<Renderer>();
    }

    // 外部から呼び出されるメソッド：無敵効果を開始する
    public void ActivateInvincibility(int blinkCount)
    {
        // 当たり判定を無効にする
        collider.enabled = false;
        // 点滅効果を開始するためのコルーチンを呼び出す
        StartCoroutine(StartInvincibilityEffect(blinkCount));
    }

    // IEnumeratorを使って、一定の時間ごとに処理を行うコルーチン
    private IEnumerator StartInvincibilityEffect(int blinkCount)
    {
        // オブジェクトの表示を非表示にする
        renderer.enabled = false;

        // 指定された回数だけ点滅処理を繰り返す
        for (int i = 0; i < blinkCount; i++)
        {
            // BlinkInterval秒待つ
            yield return new WaitForSeconds(BlinkInterval);
            // オブジェクトの表示を切り替える（点滅させる）
            renderer.enabled = !renderer.enabled;
        }

        // PostBlinkDelay秒待つ
        yield return new WaitForSeconds(PostBlinkDelay);

        // オブジェクトの表示を元に戻す
        renderer.enabled = true;
        // 当たり判定を有効に戻す
        collider.enabled = true;
    }
}
