using UnityEngine;

public class RockMovement : MonoBehaviour
{
    public float fallSpeed = 5.0f;        // 岩の落下速度
    public float initialDelay = 2.0f;     // 初期遅延時間

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        // 岩に重力を適用して、一定時間後に垂直に落下させる
        rb.useGravity = false;
        Invoke("StartFalling", initialDelay);
    }

    private void StartFalling()
    {
        // 初期遅延後に岩の初速度を設定し、下に向かって垂直に落下するようにする
        rb.useGravity = true;
        rb.velocity = new Vector3(0, -fallSpeed, 0);
    }
}
