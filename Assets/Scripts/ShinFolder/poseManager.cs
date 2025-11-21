using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class poseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private Button ResumeButton;
    [SerializeField] private Button TitleButton;

    private bool isPaused = false;

    private void Start()
    {
        //パネル非表示
        pauseMenuUI.SetActive(false);

        //ボタンにリスナーを追加
        ResumeButton.onClick.AddListener(ResumeGame);
        TitleButton.onClick.AddListener(ChangeScene_Ti);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if(isPaused)
        {
            ResumeGame();
        }
        else
        {
            pauseGame();
        }
    }

    public void pauseGame()
    {
        //ゲーム時間停止
        Time.timeScale = 0f;
        //UI表示
        pauseMenuUI.SetActive(true);

        //ポーズ状態を更新
        isPaused = true;
    }

    public void ResumeGame()
    {
        //ゲーム時間を通常に戻す
        Time.timeScale = 1f;

        //UI非表示
        pauseMenuUI.SetActive(false);

        //ポーズ状態を更新
        isPaused = false;
    }

    public void ChangeScene_Ti()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
