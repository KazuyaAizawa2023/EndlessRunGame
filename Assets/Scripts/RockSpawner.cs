using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public GameObject rockPrefab;    // ��̃v���n�u
    public float spawnInterval = 3.0f; // ��̐����Ԋu�i�b�j

    private Camera mainCamera;
    private float timer = 0.0f;

    private void Start()
    {
        mainCamera = Camera.main; // �J�������擾
    }

    private void Update()
    {
        timer += Time.deltaTime; // �o�ߎ��Ԃ��X�V

        // �w��̊Ԋu���ƂɊ�𐶐�
        if (timer >= spawnInterval)
        {
            SpawnRock(); // ��𐶐����郁�\�b�h���Ăяo��
            timer = 0.0f; // �^�C�}�[�����Z�b�g
        }
    }

    void SpawnRock()
    {
        // �����_���Ȉʒu�𐶐��i��ʓ��̃����_���Ȉʒu���擾�j
        Vector3 randomViewportPoint = new Vector3(Random.value, Random.value, 0);
        Vector3 randomWorldPoint = mainCamera.ViewportToWorldPoint(randomViewportPoint);

        // ��𐶐����A��O�ɔz�u
        GameObject rock = Instantiate(rockPrefab, randomWorldPoint, Quaternion.identity);
        rock.transform.position = new Vector3(rock.transform.position.x, rock.transform.position.y, 0); // Z���W����O�ɔz�u
    }
}
