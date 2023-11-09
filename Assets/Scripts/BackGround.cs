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

        //Yが-19.17まで下がったら、12まで戻す
        if (transform.position.y <= -12f)
        {
            transform.position = new Vector2(0, 12f);
        }
    }
}