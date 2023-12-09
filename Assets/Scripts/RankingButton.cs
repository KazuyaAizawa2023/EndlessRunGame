using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RankingButton : MonoBehaviour
{

    public void Start()
    {
        var button = GetComponent<Button>();

        // ボタンを押したときのリスナー設定
        button.onClick.AddListener(() =>
        {
            // 説明シーンをロード
            SceneManager.LoadScene("RankingScene");
        });

    }
}