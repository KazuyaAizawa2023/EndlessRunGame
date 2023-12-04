using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(CircleCollider2D))]

public class InvincibilityEffect : MonoBehaviour
{
    private SpriteRenderer spriterenderer;      // ゲームオブジェクトのSpriteRendererコンポーネント
    private CircleCollider2D circleCollider2D;  // ゲームオブジェクトのCircleCollider2Dコンポーネント

    private const float BlinkInterval = 0.15f;   // 点滅効果の切り替え間隔
    private const float PostBlinkDelay = 0.3f;  // 点滅効果終了後の遅延時間

    void Start()
    {
        // コンポーネントの取得
        circleCollider2D = GetComponent<CircleCollider2D>();
        spriterenderer = GetComponent<SpriteRenderer>();

        // Rigidbody2Dを削除するか、無効にする
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        if (rigidbody2D != null)
        {
            Destroy(rigidbody2D); // Rigidbody2Dを削除
        }
    }

    // 無敵効果を開始するメソッド
    public void ActivateInvincibility(int blinkCount)
    {
        // 無敵効果を開始する際にColliderを無効にし、コルーチンを開始
        circleCollider2D.enabled = false;
        StartCoroutine(StartInvincibilityEffect(blinkCount));
    }

    // 無敵効果を実現するコルーチン
    private IEnumerator StartInvincibilityEffect(int blinkCount)
    {
        Debug.Log("StartInvincibilityEffect coroutine started");

        // 無敵効果開始時にRendererを非表示にする
        spriterenderer.enabled = false;

        for (int i = 0; i < blinkCount; i++)
        {
            // 一定時間ごとにspriterRendererの表示/非表示を切り替える
            yield return new WaitForSeconds(BlinkInterval);
            spriterenderer.enabled = !spriterenderer.enabled;
        }

        // ピカピカ効果が終わった後に再びRendererを表示し、Colliderを有効にする
        yield return new WaitForSeconds(PostBlinkDelay);
        spriterenderer.enabled = true;
        circleCollider2D.enabled = true;
    }
}
