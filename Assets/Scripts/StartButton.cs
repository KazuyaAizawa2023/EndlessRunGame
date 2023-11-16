using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    
    public void Start()
    {
        var button = GetComponent<Button>();

        // ボタンを押したときのリスナー設定
        button.onClick.AddListener(() =>
        {
            // 説明シーンをロード
            SceneManager.LoadScene("GameScene");
        });

    }
}




//public class StartButton : MonoBehaviour
//{
//    public float explanationDuration = 2.0f; // 説明の表示時間（秒）

//    public void Start()
//    {
//        var button = GetComponent<Button>();

//        // ボタンを押したときのリスナー設定
//        button.onClick.AddListener(() =>
//        {
//            // 説明シーンをロード
//            SceneManager.LoadScene("ExplanationScene");
//        });

//        // 一定時間後にゲームスタート
//        Invoke("StartGame", explanationDuration);
//    }

//    // ゲームスタート時の処理
//    private void StartGame()
//    {
//        Debug.Log("StartGame method called");
//        // ゲームシーンをロード
//        SceneManager.LoadScene("GameScene");
//    }
//}