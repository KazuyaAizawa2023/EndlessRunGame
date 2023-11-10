using UnityEngine;

public class RockMovement : MonoBehaviour
{
    public float fallSpeed = 5.0f;        // ��̗������x
    public float initialDelay = 2.0f;     // �����x������

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        // ��ɏd�͂�K�p���āA��莞�Ԍ�ɐ����ɗ���������
        rb.useGravity = false;
        Invoke("StartFalling", initialDelay);
    }

    private void StartFalling()
    {
        // �����x����Ɋ�̏����x��ݒ肵�A���Ɍ������Đ����ɗ�������悤�ɂ���
        rb.useGravity = true;
        rb.velocity = new Vector3(0, -fallSpeed, 0);
    }
}
