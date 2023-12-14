using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{
    public GameObject popupPanel;
    public Button endButton;

    void Start()
    {
        popupPanel.SetActive(false);

        // ポーズボタンにクリックリスナーを追加
        if (endButton != null)
        {
            endButton.onClick.AddListener(ShowPopup);
        }
        else
        {
            Debug.LogError("EndButton not assigned in the inspector.");
        }
    }

    void ShowPopup()
    {
        // ポップアップを表示
        popupPanel.SetActive(true);
    }

    public void YesButtonClicked()
    {
        // ゲームを終了する処理を追加
        Debug.Log("ゲームを終了します");
        Application.Quit();
    }

    public void NoButtonClicked()
    {
        // ポップアップを非表示にする代わりにEndSceneに移動
        SceneManager.LoadScene("EndScene");
    }
}
