using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f; // 移動速度を調整できるようにする

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
        viewPos.x = Mathf.Clamp(viewPos.x, 0.0f, 1.0f);
        transform.position = Camera.main.ViewportToWorldPoint(viewPos);
    }
}