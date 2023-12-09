using UnityEngine;
using UnityEngine.UI;

public class EndScene : MonoBehaviour
{
    public Text scoreText;  // EndSceneのUIテキスト

    void Start()
    {
        // PlayerPrefsを使用してGameManagerからスコアを取得
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0);

        // EndSceneのUIテキストにスコアを表示
        if (scoreText != null)
        {
            scoreText.text = "Score: " + finalScore.ToString();
        }
    }
}
