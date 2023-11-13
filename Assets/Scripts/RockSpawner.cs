using System.Collections;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public GameObject rockPrefab;    // ��̃v���n�u
    public float spawnInterval = 3.0f; // ��̐����Ԋu�i�b�j
    public float initialDelay = 2.0f;  // �����x������

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main; // �J�������擾

        // Coroutine���J�n
        StartCoroutine(SpawnRocksCoroutine());
    }

    private IEnumerator SpawnRocksCoroutine()
    {
        // �����x��
        yield return new WaitForSeconds(initialDelay);

        while (true)
        {
            // �����_���Ȉʒu�𐶐��i��ʂ̏㔼���̃����_���Ȉʒu���擾�j
            Vector3 randomViewportPoint = new Vector3(Random.value, Random.Range(0.5f, 1.0f), 0);
            Vector3 randomWorldPoint = mainCamera.ViewportToWorldPoint(randomViewportPoint);

            // ��𐶐����A��O�ɔz�u
            GameObject rock = Instantiate(rockPrefab, randomWorldPoint, Quaternion.identity);
            rock.transform.position = new Vector3(rock.transform.position.x, rock.transform.position.y, 0); // Z���W����O�ɔz�u

            // �������ꂽ��� RockMovement �X�N���v�g���A�^�b�`
            rock.AddComponent<RockMovement>();

            // �w��̊Ԋu�����ҋ@
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}

