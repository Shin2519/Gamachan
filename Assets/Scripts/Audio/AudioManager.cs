using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField, Header("AudioMixer")]
    private AudioMixer mixer;

    [SerializeField] private AudioSource bgmSource;
    [SerializeField] private AudioSource seSource;


    public AudioClip[] SE;
    public AudioClip[] BGM;

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
            return;
        }
    }

    void Start()
    {
        SetBGMVolume(PlayerPrefs.GetFloat("BGMVolume", 1f));
        SetSEVolume(PlayerPrefs.GetFloat("SEVolume", 1f));
        SetMasterVolume(PlayerPrefs.GetFloat("MasterVolume", 1f));
        
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "TitleScene")
        PlayBGM(BGM[0]);
    }
    public void PlayBGM(AudioClip clip,bool loop = true)
    {
        if (clip == null) return;

        if (bgmSource.clip == clip && bgmSource.isPlaying) return;
        
        bgmSource.clip = clip;
        bgmSource.loop = loop;
        bgmSource.Play();
    }

    public void StopBGM()
    {
        bgmSource.Stop();
    }

    public void PlaySE(AudioClip clip)
    {
        if(clip == null) return;

        seSource.PlayOneShot(clip);
    }

    public void SetBGMVolume(float volume)
    {
        volume = Mathf.Clamp(volume, 0.001f, 1f);

        mixer.SetFloat("BGMVolume",Mathf.Log10(volume)*20);

        PlayerPrefs.SetFloat("BGMVolume",volume);
        PlayerPrefs.Save();
    }

    public void SetSEVolume(float volume)
    {
        volume = Mathf.Clamp(volume, 0.001f, 1f);

        mixer.SetFloat("SEVolume", Mathf.Log10(volume) * 20);

        PlayerPrefs.SetFloat("SEVolume", volume);
        PlayerPrefs.Save();
    }
    public void SetMasterVolume(float volume)
    {
        volume = Mathf.Clamp(volume, 0.001f, 1f);

        mixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);

        PlayerPrefs.SetFloat("MasterVolume", volume);
        PlayerPrefs.Save();
    }

    public float GetBGMVolume()
    {
        return PlayerPrefs.GetFloat("BGMVolume", 1f);
    }

    public float GetSEVolume()
    {
        return PlayerPrefs.GetFloat("SEVolume", 1f);
    }

    public float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat("MasterVolume", 1f);
    }
}
