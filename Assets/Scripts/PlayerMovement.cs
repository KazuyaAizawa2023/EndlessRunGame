using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f; // 移動速度を調整できるようにする

    private PlayerHealthUI playerHealthUI;

    void Start()
    {
        // PlayerHealthUIクラスのインスタンスを取得
        playerHealthUI = FindObjectOfType<PlayerHealthUI>();
    }

    void Update()
    {
        // 左矢印が押されたとき
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime); // 左に移動
        }

        // 右矢印が押されたとき
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime); // 右に移動
        }

        // 画面外に出ないように制限をかける
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

        // プレイヤーが画面外に出ないように、画面の端に対して一定のマージンを設ける
        float margin = 0.05f;  // マージンの割合を調整可能

        viewPos.x = Mathf.Clamp(viewPos.x, margin, 1.0f - margin);

        transform.position = Camera.main.ViewportToWorldPoint(viewPos);


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Rock"))
        {
            playerHealthUI.HandleObstacleCollision();
        }
    }

    void HandleObstacleCollision()
    {
        Debug.Log("Player collided with Rock");
        // ここでプレイヤーとの衝突に対する追加の処理を行う（例: ダメージを受けるなど）
    }
}