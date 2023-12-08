using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<AudioManager>();

                if (instance == null)
                {
                    GameObject obj = new GameObject("AudioManager");
                    instance = obj.AddComponent<AudioManager>();
                    obj.AddComponent<AudioSource>(); // AudioManager ゲームオブジェクトに AudioSource をアタッチ
                }
            }
            return instance;
        }
    }

    private AudioSource audioSource;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>(); // コンポーネントを取得する

        if (audioSource == null)
        {
            Debug.LogError("AudioSource component not found on AudioManager");
        }

        // 2Dサウンドに設定
        audioSource.spatialBlend = 0;
    }

    public void PlaySound(AudioClip sound)
    {
        if (audioSource != null && sound != null && !audioSource.isPlaying)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(sound);
        }
    }
}
