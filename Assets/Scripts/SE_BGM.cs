using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SE_BGM: MonoBehaviour
{
    [Header("UI")]
    public Button backButton;

    [Header("Audio")]
    public AudioSource bgmSource;
    public AudioSource seSource;
    public AudioClip backSE; 

    void Start()
    {
        float bgmVolume = PlayerPrefs.GetFloat("BGMVolume", 0.5f);
        float seVolume = PlayerPrefs.GetFloat("SEVolume", 0.5f);

        bgmSource.volume = bgmVolume;
        seSource.volume = seVolume;

        // 戻るボタンにイベント登録
        backButton.onClick.AddListener(OnBackButtonPressed);
    }

    public void OnBackButtonPressed()
    {
        if (backSE != null && seSource != null)
        {
            seSource.PlayOneShot(backSE);
        }

        SceneManager.LoadScene("TitleScene");
    }
}
