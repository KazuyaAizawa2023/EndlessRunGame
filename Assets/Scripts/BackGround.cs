using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    //スクロールスピード
    [SerializeField] float speed = 1;

    void Update()
    {
        //下方向に動かす
        transform.position -= new Vector3(0, Time.deltaTime * speed);

        //Yが-12まで下がったら、12まで戻す
        //背景が一定の位置（ここではY座標が-12）まで下がったら、再び指定の位置に戻す処理
        //これにより、無限にスクロールするような効果
        if (transform.position.y <= -12f)
        {
            transform.position = new Vector2(0, 12f);
        }
    }
}