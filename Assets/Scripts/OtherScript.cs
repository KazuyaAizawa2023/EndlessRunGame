using UnityEngine;

public class OtherScript : MonoBehaviour
{
    // Inspectorから設定するか、コードで割り当てるための変数
    public GameObject targetObject;

        void Start()
    {
        targetObject = GameObject.FindWithTag("Player"); // あるいは適切な方法でプレイヤーオブジェクトを取得する
    }

    // 何らかの処理を行うメソッド
    void SomeMethod()
    {
        Debug.Log("SomeMethod is called"); // デバッグメッセージ

        // targetObjectにアタッチされたInvincibilityEffectスクリプトを取得する
        InvincibilityEffect invincibilityEffect = targetObject.GetComponent<InvincibilityEffect>();

        // もしInvincibilityEffectが取得できた場合
        if (invincibilityEffect != null)
        {
            // 取得したInvincibilityEffectのActivateInvincibilityメソッドを呼び出し、引数に9を渡す
            invincibilityEffect.ActivateInvincibility(9);
        }
    }
}
