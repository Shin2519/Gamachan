using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionManager : MonoBehaviour
{
    public Slider bgmSlider;
    public Slider seSlider;
    public AudioSource bgmSource;
    public AudioSource seSource;

    void Start()
    {
        float bgmVolume = PlayerPrefs.GetFloat("BGMVolume", 0.5f);
        float seVolume = PlayerPrefs.GetFloat("SEVolume", 0.5f);

        bgmSlider.value = bgmVolume;
        seSlider.value = seVolume;

        bgmSource.volume = bgmVolume;
        seSource.volume = seVolume;
    }

    public void OnBGMVolumeChanged()
    {
        bgmSource.volume = bgmSlider.value;
        PlayerPrefs.SetFloat("BGMVolume", bgmSlider.value);
    }

    public void OnSEVolumeChanged()
    {
        seSource.volume = seSlider.value;
        PlayerPrefs.SetFloat("SEVolume", seSlider.value);
    }

    public void OnBackButtonPressed()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
