using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public GameObject rockPrefab;    // ��̃v���n�u
    public float spawnInterval = 3.0f; // ��̐����Ԋu�i�b�j
    public float initialDelay = 2.0f;  // �����x������

    private Camera mainCamera;
    private float timer = 0.0f;

    private void Start()
    {
        mainCamera = Camera.main; // �J�������擾

        // �ŏ��̊�𐶐�
        SpawnRockDelayed(initialDelay);
    }

    private void Update()
    {
        timer += Time.deltaTime; // �o�ߎ��Ԃ��X�V

        // �w��̊Ԋu���ƂɊ�𐶐�
        if (timer >= spawnInterval)
        {
            SpawnRockDelayed(0.0f); // ��𐶐����郁�\�b�h���Ăяo���i�����x���Ȃ��j
            timer = 0.0f; // �^�C�}�[�����Z�b�g
        }
    }

    void SpawnRockDelayed(float delay)
    {
        // �w��̒x�����Ԍ�Ɋ�𐶐�
        Invoke("SpawnRock", delay);
    }

    void SpawnRock()
    {
        // �����_���Ȉʒu�𐶐��i��ʓ��̃����_���Ȉʒu���擾�j
        Vector3 randomViewportPoint = new Vector3(Random.value, Random.Range(0.5f, 1.0f), 0); // Y���W��1.0f�ɐݒ肵�ĉ�ʂ̏㕔�ɐ���
        Vector3 randomWorldPoint = mainCamera.ViewportToWorldPoint(randomViewportPoint);

        // ��𐶐����A��O�ɔz�u
        GameObject rock = Instantiate(rockPrefab, randomWorldPoint, Quaternion.identity);
        rock.transform.position = new Vector3(rock.transform.position.x, rock.transform.position.y, 0); // Z���W����O�ɔz�u

        // �������ꂽ��� RockMovement �X�N���v�g���A�^�b�`
        rock.AddComponent<RockMovement>();
    }
}

