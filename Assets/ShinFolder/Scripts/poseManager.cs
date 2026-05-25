using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class poseManager : MonoBehaviour
{
    [SerializeField] private Sound sound;
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private Button ResumeButton;
    [SerializeField] private Button TitleButton;
    [SerializeField] private Button PoseButton;
    [SerializeField] private GameObject Resultpanel;

    private bool isPaused = false;

    //音量設定用
    public Slider bgmSlider;
    public Slider seSlider;
    public Button backButton;
    public AudioSource bgmSource;
    public AudioSource seSource;

    private void Start()
    {
        //パネル非表示
        pauseMenuUI.SetActive(false);

        //ボタンにリスナーを追加
        ResumeButton.onClick.AddListener(ResumeGame);
        TitleButton.onClick.AddListener(ChangeButton_Ti);
        PoseButton.onClick.AddListener(TogglePause);

        //音量設定用
        float bgmVolume = PlayerPrefs.GetFloat("BGMVolume", 0.5f);
        float seVolume = PlayerPrefs.GetFloat("SEVolume", 0.5f);

        bgmSlider.value = bgmVolume;
        seSlider.value = seVolume;

        bgmSource.volume = bgmVolume;
        seSource.volume = seVolume;

        bgmSlider.onValueChanged.AddListener(delegate { OnBGMVolumeChanged(); });
        seSlider.onValueChanged.AddListener(delegate { OnSEVolumeChanged(); });
        //backButton.onClick.AddListener(OnBackButtonPressed);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void OnClick()
    {
        pauseGame();
    }

    public void TogglePause()
    {
        if(!pauseMenuUI.activeSelf)
        {
            pauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    public void pauseGame()
    {
        if (Resultpanel.activeSelf) return;

        //ゲーム時間停止
        Time.timeScale = 0f;
        //UI表示
        pauseMenuUI.SetActive(true);
        //ポーズ状態を更新
        isPaused = true;
    }

    public void ResumeGame()
    {
        if (Resultpanel.activeSelf) return;

        //ゲーム時間を通常に戻す
        Time.timeScale = 1f;

        pauseMenuUI.SetActive(false);

        //ポーズ状態を更新
        isPaused = false;
    }

    //音量設定用
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
        AudioManager.Instance.seSource.PlayOneShot(sound.Back);
    }

    public void ChangeButton_Ti()
    {
        FadeManager.Instance.LoadLevel("TitleScene", 1.0f, null, null);
        SceneManager.LoadScene("TitleScene");
    }
}
