﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;                     // スコアを表示するテキスト
    private float score = 0.0f;                // 現在のスコア
    public float scoreIncreaseAmount = 1.0f;   // スコアが増える量
    private int currentLevel = 1;               // 現在のレベル

    private PlayerMovement playerMovement;
    private RockSpawner rockSpawner;

    void Start()
    {
        // PlayerMovement と RockSpawner を探して参照を取得
        playerMovement = FindObjectOfType<PlayerMovement>();
        rockSpawner = FindObjectOfType<RockSpawner>();

        UpdateScoreText();
        StartCoroutine(IncreaseScore());
    }

    void UpdateScoreText()
    {
        // スコアとレベルをテキストに表示
        if (scoreText != null)  // null チェックを追加
        {
            scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString() + " | Level: " + currentLevel.ToString();
        }
    }

    IEnumerator IncreaseScore()
    {
        while (true)
        {
            // 一定の間隔ごとにスコアが増える
            score += scoreIncreaseAmount;
            UpdateScoreText();   // スコア表示を更新

            // スコアが50の倍数のときにレベルアップ
            if (Mathf.FloorToInt(score) % 50 == 0)
            {
                LevelUp();
            }

            yield return new WaitForSeconds(1.0f); // 1秒ごとにスコアが増える例
        }
    }

    void LevelUp()

    {
        // レベルアップ時の処理
        currentLevel++;

        // プレイヤーの速度を15%増加
        playerMovement.moveSpeed *= 1.15f;

        // 障害物の生成間隔を30%減少
        rockSpawner.spawnInterval *= 0.7f;

        // ここで必要なレベルアップ時の処理を追加
    }
    
}
