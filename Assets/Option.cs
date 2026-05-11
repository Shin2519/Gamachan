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

    private void Start()
    {
        // 保存された音量を読み込む（なければ1.0）
        float bgmVolume = PlayerPrefs.GetFloat("BGM_VOLUME", 1.0f);
        float seVolume = PlayerPrefs.GetFloat("SE_VOLUME", 1.0f);

        // スライダーに反映
        bgmSlider.value = bgmVolume;
        seSlider.value = seVolume;

        // AudioSource に反映
        if (bgmSource != null) bgmSource.volume = bgmVolume;
        if (seSource != null) seSource.volume = seVolume;

        // スライダー変更時のイベント登録
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

    // ★ タイトルへ戻る（フェード付き）
    public void GoToTitleScene()
    {
        FadeManager.Instance.LoadLevel("TitleScene", 1.0f, null, null);
    }
}
