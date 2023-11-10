// 岩が垂直に落下する動きをつけるスクリプト
using UnityEngine;

public class RockMovement : MonoBehaviour
{
    public float fallSpeed = 5.0f; // 岩の落下速度

    private Rigidbody rb;

    private void Start()
    {
        // ゲームが始まった瞬間に実行される部分。
        // 岩に物理法則（重力）を適用して、岩が自動的に下に落ちるようにする。

        rb = GetComponent<Rigidbody>();

        // 岩に重力を適用して垂直に落下させる
        rb.useGravity = true;

        // 岩の初速度を設定し、下に向かって垂直に落下するようにする。
        rb.velocity = new Vector3(0, -fallSpeed, 0);
    }
}
