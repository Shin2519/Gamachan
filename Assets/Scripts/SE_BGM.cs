using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SE_BGM: MonoBehaviour
{
    [Header("UI")]
    public Button backButton;
    [SerializeField]
    private Sound sound;

    [Header("Audio")]
    public AudioSource bgmSource;
    public AudioSource seSource;

    void Start()
    {
        float bgmVolume = PlayerPrefs.GetFloat("BGMVolume", 0.5f);
        float seVolume = PlayerPrefs.GetFloat("SEVolume", 0.5f);

        bgmSource.volume = bgmVolume;
        seSource.volume = seVolume;

        backButton.onClick.AddListener(OnBackButtonPressed);
    }

    public void OnBackButtonPressed()
    {

        FadeManager.Instance.LoadLevel("TitleScene", 1.0f, null, null);
    }
}
