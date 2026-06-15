using UnityEngine;
using UnityEngine.UI;

public class poseManager : MonoBehaviour
{
    [SerializeField] private Sound sound;
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private Button ResumeButton;
    [SerializeField] private Button TitleButton;
    [SerializeField] private GameObject Resultpanel;

    private bool isPaused = false;

    //���ʐݒ�p
    public Slider bgmSlider;
    public Slider seSlider;
    public Button backButton;
    public AudioSource bgmSource;
    public AudioSource seSource;

    private void Start()
    {
        //�p�l����\��
        pauseMenuUI.SetActive(false);

        //�{�^���Ƀ��X�i�[��ǉ�
        //ResumeButton.onClick.AddListener(ResumeGame);
        //TitleButton.onClick.AddListener(ChangeScene_Ti);

        //���ʐݒ�p
        float bgmVolume = PlayerPrefs.GetFloat("BGMVolume", 0.5f);
        float seVolume = PlayerPrefs.GetFloat("SEVolume", 0.5f);

        bgmSlider.value = bgmVolume;
        seSlider.value = seVolume;

        bgmSlider.onValueChanged.AddListener(delegate { OnVolumeChanged(bgmSlider.value,bgmSource.volume,"BGMVolume"); });
        seSlider.onValueChanged.AddListener(delegate { OnVolumeChanged(seSlider.value,seSource.volume,"SEVolume"); });
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

        //�Q�[�����Ԓ�~
        Time.timeScale = 0f;
        //UI�\��
        pauseMenuUI.SetActive(true);
        //�|�[�Y��Ԃ��X�V
        isPaused = true;
    }

    public void ResumeGame()
    {
        if (Resultpanel.activeSelf) return;

        //�Q�[�����Ԃ�ʏ�ɖ߂�
        Time.timeScale = 1f;

        pauseMenuUI.SetActive(false);

        //�|�[�Y��Ԃ��X�V
        isPaused = false;
    }

    //���ʐݒ�p
    
    void OnVolumeChanged(float l_slider_value,float l_Source_value,string l_volumename)
    {
        l_Source_value = l_slider_value;
        PlayerPrefs.SetFloat(l_volumename, l_slider_value);
        PlayerPrefs.Save();
    }

    public void OnBackButtonPressed()
    {

        //SceneManager.LoadScene("TitleScene");
    }

    public void ChangeButton_Ti()
    {
        FadeManager.Instance.LoadLevel("TitleScene", 1.0f, null, null);
        //SceneManager.LoadScene("TitleScene");
    }
}
