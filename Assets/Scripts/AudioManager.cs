using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource bgmSource;
    public AudioSource seSource;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        bgmSource.volume = PlayerPrefs.GetFloat("BGMVolume", 0.5f);
        seSource.volume = PlayerPrefs.GetFloat("SEVolume", 0.5f);
    }
}
