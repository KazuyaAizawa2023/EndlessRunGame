using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public void Start()
    {
        var button = GetComponent<Button>();

        //ボタンを押したときのリスナー設定
        button.onClick.AddListener(() =>
        {
            //シーン転移の際にはSceneManagerを使用する
            SceneManager.LoadScene("GameScene");
        });
    }

}
