using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    public Image[] lifeIcons;
    private int maxLife = 5;
    private int currentLife;
    private GameManager gameManager;  // GameManagerの参照を保持

    // 音関連の変数
    public AudioClip collisionSound; // 衝突時に再生する音
    private AudioSource audioSource;

    void Start()
    {
        // GameManagerの参照を取得
        gameManager = FindObjectOfType<GameManager>();

        currentLife = maxLife;
        UpdateUI();

        // 音の初期化
        audioSource = GetComponent<AudioSource>();
        if (collisionSound == null)
        {
            Debug.LogWarning("Collision sound is not set.");
        }
    }

    void UpdateUI()
    {
        for (int i = 0; i < lifeIcons.Length; i++)
        {
            if (i < currentLife)
            {
                lifeIcons[i].enabled = true;
            }
            else
            {
                lifeIcons[i].enabled = false;
            }
        }
    }

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

    public void HandleObstacleCollision()
    {
        Debug.Log("Player collided with Rock");

        // 音を再生
        PlayCollisionSound();

        // ダメージ処理など他の処理も含めてここで行う
        DecreaseLife();

        // プレイヤーのGameObjectからInvincibilityEffectスクリプトを取得
        InvincibilityEffect invincibilityEffect = GetComponent<InvincibilityEffect>();

        // もしInvincibilityEffectが取得できた場合
        if (invincibilityEffect != null)
        {
            // 取得したInvincibilityEffectのActivateInvincibilityメソッドを呼び出し、引数に9を渡す
            invincibilityEffect.ActivateInvincibility(9);
        }

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

    private void PlayCollisionSound()
    {
        if (audioSource != null && collisionSound != null)
        {
            audioSource.PlayOneShot(collisionSound);
        }
    }
}

