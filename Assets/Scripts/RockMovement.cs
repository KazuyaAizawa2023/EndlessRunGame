using UnityEngine;

public class RockMovement : MonoBehaviour
{
    public float fallSpeed = 10.0f;        // 岩の落下速度
    public float initialDelay = 2.0f;     // 初期遅延時間

    private Rigidbody2D rb2D;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();

        // 岩に重力を適用して、一定時間後に垂直に落下させる
        rb2D.gravityScale = 1.0f; // 通常の重力を適用
        rb2D.velocity = new Vector2(0, -fallSpeed); // 2D向けに修正
    }



    // 衝突した瞬間に呼び出されるメソッド
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 衝突した相手がプレイヤーだった場合
        if (collision.gameObject.CompareTag("Player"))
        {
            // 岩を削除する
            Destroy(gameObject);
        }
    }
}