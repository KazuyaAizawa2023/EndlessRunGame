using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    //�X�N���[���X�s�[�h
    [SerializeField] float speed = 1;

    void Update()
    {
        //�������ɓ�����
        transform.position -= new Vector3(0, Time.deltaTime * speed);

        //Y��-19.17�܂ŉ���������A12�܂Ŗ߂�
        if (transform.position.y <= -12f)
        {
            transform.position = new Vector2(0, 12f);
        }
    }
}