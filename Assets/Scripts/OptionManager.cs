using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionManager : MonoBehaviour
{
    public Slider bgmSlider;
    public Slider seSlider;
    public Button backButton;
    public AudioSource bgmSource;
    public AudioSource seSource;
    public AudioClip backSE; // –ß‚éƒ{ƒ^ƒ“—p‚ÌŒø‰Ê‰¹

    void Start()
    {
        float bgmVolume = PlayerPrefs.GetFloat("BGMVolume", 0.5f);
        float seVolume = PlayerPrefs.GetFloat("SEVolume", 0.5f);

        bgmSlider.value = bgmVolume;
        seSlider.value = seVolume;

        bgmSource.volume = bgmVolume;
        seSource.volume = seVolume;

        bgmSlider.onValueChanged.AddListener(delegate { OnBGMVolumeChanged(); });
        seSlider.onValueChanged.AddListener(delegate { OnSEVolumeChanged(); });
        backButton.onClick.AddListener(OnBackButtonPressed);
    }

    public void OnBGMVolumeChanged()
    {
        bgmSource.volume = bgmSlider.value;
        PlayerPrefs.SetFloat("BGMVolume", bgmSlider.value);
        PlayerPrefs.Save();
    }

    public void OnSEVolumeChanged()
    {
        seSource.volume = seSlider.value;
        PlayerPrefs.SetFloat("SEVolume", seSlider.value);
        PlayerPrefs.Save();
    }

    public void OnBackButtonPressed()
    {
        if (backSE != null)
        {
            seSource.PlayOneShot(backSE);
        }

        FadeManager.Instance.LoadLevel("TitleScene", 1.0f, null, null);
    }
}
