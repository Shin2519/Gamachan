using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField]
    private Sound sound;
    public AudioSource bgmSource;
    public AudioSource seSource;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        bgmSource.volume = PlayerPrefs.GetFloat("BGMVolume", 0.5f);
        seSource.volume = PlayerPrefs.GetFloat("SEVolume", 0.5f);
        //bgmSource.resource = sound.resource;
    }
}
