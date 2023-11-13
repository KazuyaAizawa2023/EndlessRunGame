using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;             // スコアを表示するテキスト
    private float score = 0.0f;         // 現在のスコア
    public float scoreIncreaseAmount = 1.0f;   // スコアが増える量
    private int currentLevel = 1;       // 現在のレベル

    void Start()
    {
        UpdateScoreText();  // ゲーム開始時にスコアを表示
        StartCoroutine(IncreaseScore());   // スコアを増やすコルーチンを開始
    }

    void UpdateScoreText()
    {
        // スコアとレベルをテキストに表示
        scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString() + " | Level: " + currentLevel.ToString();
    }

    IEnumerator IncreaseScore()
    {
        while (true)
        {
            // 一定の間隔ごとにスコアが増える
            score += scoreIncreaseAmount;
            UpdateScoreText();   // スコア表示を更新
            yield return new WaitForSeconds(1.0f); // 1秒ごとにスコアが増える例
        }
    }
}
