using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    public Image[] lifeIcons; // ライフのアイコンを格納する Image 配列
    private int maxLife = 3;
    private int currentLife;

    void Start()
    {
        currentLife = maxLife;
        UpdateUI();
    }

    // UI を更新するメソッド
    void UpdateUI()
    {
        // ライフのアイコンを更新
        for (int i = 0; i < lifeIcons.Length; i++)
        {
            if (i < currentLife)
            {
                lifeIcons[i].enabled = true; // ライフが残っていれば表示
            }
            else
            {
                lifeIcons[i].enabled = false; // ライフがなければ非表示
            }
        }
    }

    // ライフを減少させるメソッド
    public void DecreaseLife()
    {
        currentLife--;

        Debug.Log("Life decreased. Current Life: " + currentLife);

        if (currentLife <= 0)
        {
            Debug.Log("Game Over!");
            ShowGameOverScreen();
        }

        UpdateUI();
    }

    // 障害物との衝突を処理するメソッド
    public void HandleObstacleCollision()
    {
        Debug.Log("Player collided with Rock");
        // ここでプレイヤーとの衝突に対する追加の処理を行う（例: ダメージを受けるなど）
        DecreaseLife();
    }

    // ゲームオーバー時の処理を行うメソッド
    void ShowGameOverScreen()
    {
        // エンドスクリーンのシーンに切り替える
        SceneManager.LoadScene("EndScene");
    }
}
