using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    public AudioClip clickSE; // InspectorÇ≈ê›íËÇ∑ÇÈ
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GameObject.Find("SEPlayer").GetComponent<AudioSource>();
    }

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
