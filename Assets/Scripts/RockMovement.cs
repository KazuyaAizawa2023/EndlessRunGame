// �₪�����ɗ������铮��������X�N���v�g
using UnityEngine;

public class RockMovement : MonoBehaviour
{
    public float fallSpeed = 5.0f; // ��̗������x

    private Rigidbody rb;

    private void Start()
    {
        // �Q�[�����n�܂����u�ԂɎ��s����镔���B
        // ��ɕ����@���i�d�́j��K�p���āA�₪�����I�ɉ��ɗ�����悤�ɂ���B

        rb = GetComponent<Rigidbody>();

        // ��ɏd�͂�K�p���Đ����ɗ���������
        rb.useGravity = true;

        // ��̏����x��ݒ肵�A���Ɍ������Đ����ɗ�������悤�ɂ���B
        rb.velocity = new Vector3(0, -fallSpeed, 0);
    }
}
