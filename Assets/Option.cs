using UnityEngine;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    [Header("スライダー")]
    public Slider bgmSlider;
    public Slider seSlider;

    [Header("AudioSource")]
    public AudioSource bgmSource;
    public AudioSource seSource;

    [Header("オプションパネル")]
    public GameObject optionPanel;   // ★ 追加：パネルを閉じるため

    private void Start()
    {
        float bgmVolume = PlayerPrefs.GetFloat("BGM_VOLUME", 1.0f);
        float seVolume = PlayerPrefs.GetFloat("SE_VOLUME", 1.0f);

        bgmSlider.value = bgmVolume;
        seSlider.value = seVolume;

        if (bgmSource != null) bgmSource.volume = bgmVolume;
        if (seSource != null) seSource.volume = seVolume;

        bgmSlider.onValueChanged.AddListener(OnBGMVolumeChanged);
        seSlider.onValueChanged.AddListener(OnSEVolumeChanged);
    }

    private void OnBGMVolumeChanged(float value)
    {
        if (bgmSource != null) bgmSource.volume = value;
        PlayerPrefs.SetFloat("BGM_VOLUME", value);
    }

    private void OnSEVolumeChanged(float value)
    {
        if (seSource != null) seSource.volume = value;
        PlayerPrefs.SetFloat("SE_VOLUME", value);
    }

    // ★ 戻るボタン → パネルを閉じるだけ
    public void CloseOptionPanel()
    {
        optionPanel.SetActive(false);
    }
}
