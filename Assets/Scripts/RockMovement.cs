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

    //private void Update()
    //{
    //    // 画面外に出たらオブジェクトを破棄
    //    if (IsOutOfScreen())
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    //private bool IsOutOfScreen()
    //{
    //    // 岩の位置をスクリーン座標に変換
    //    Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

    //    // 画面外に出ているかどうかを判定
    //    return (screenPos.x < 0 || screenPos.x > Screen.width || screenPos.y < 0 || screenPos.y > Screen.height);
    //}

    // リストから要素を削除してオブジェクトを破棄するメソッド
    //private void RemoveFromListAndDestroy()
    //{
    //    // rocks リストから自分（このスクリプトがアタッチされているオブジェクト）を探して削除
    //    if (rocks.Contains(gameObject))
    //    {
    //        rocks.Remove(gameObject);
    //    }

    //    // オブジェクトを破棄
    //    Destroy(gameObject);
    //}
}
