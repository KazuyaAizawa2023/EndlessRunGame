using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    public Image[] lifeIcons;
    private int maxLife = 5;
    private int currentLife;
    private GameManager gameManager;  // GameManagerの参照を保持


    void Start()
    {
        // GameManagerの参照を取得
        gameManager = FindObjectOfType<GameManager>();

        currentLife = maxLife;
        UpdateUI();
    }

    void UpdateUI()
    {
        for (int i = 0; i < lifeIcons.Length; i++)
        {
            lifeIcons[i].enabled = i < currentLife;
        }
    }

    public void DecreaseLife()
    {
        currentLife--;

        Debug.Log($"Life decreased. Current Life: {currentLife}");

        if (currentLife <= 0)
        {
            Debug.Log("Game Over!");
            ShowGameOverScreen();
        }

        UpdateUI();
    }

    public void HandleObstacleCollision()
    {
        Debug.Log("Player collided with Rock");

        // ダメージ処理など他の処理も含めてここで行う
        DecreaseLife();

        // プレイヤーのGameObjectからInvincibilityEffectスクリプトを取得
        InvincibilityEffect invincibilityEffect = GetComponent<InvincibilityEffect>();

        // もしInvincibilityEffectが取得できた場合
        invincibilityEffect?.ActivateInvincibility(9);

        // もしここで他に行いたい処理があれば追加
    }

    void ShowGameOverScreen()
    {
        // GameManagerからスコアを取得
        float finalScore = gameManager.GetScore();

        // スコアを保存
        PlayerPrefs.SetInt("FinalScore", Mathf.FloorToInt(finalScore));

        SceneManager.LoadScene("EndScene");
    }
}
