using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clickSE;

    private void PlayClickSE()
    {
        if (clickSE != null && audioSource != null)
        {
            audioSource.PlayOneShot(clickSE);
        }
    }

    public void GoToRankingScene()
    {
        PlayClickSE();
        SceneManager.LoadScene("RankingScene");
    }

    public void GoToTitleScene()
    {
        PlayClickSE();
        SceneManager.LoadScene("TitleScene");
    }

    public void GoToModeSelectScene()
    {
        PlayClickSE();
        SceneManager.LoadScene("ModeSelectScene");
    }
}
