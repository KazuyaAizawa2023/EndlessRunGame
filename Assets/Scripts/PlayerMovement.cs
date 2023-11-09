using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f; // �ړ����x�𒲐��ł���悤�ɂ���

    void Update()
    {
        // ����󂪉����ꂽ�Ƃ�
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime); // ���Ɉړ�
        }

        // �E��󂪉����ꂽ�Ƃ�
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime); // �E�Ɉړ�
        }

        // ��ʊO�ɏo�Ȃ��悤�ɐ�����������
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp(viewPos.x, 0.0f, 1.0f);
        transform.position = Camera.main.ViewportToWorldPoint(viewPos);
    }
}