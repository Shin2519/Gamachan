using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField] private string SettingScene;
    [SerializeField] private string RankingScene;


    public void ChangeButton_st()
    {
        FadeManager.Instance.LoadLevel("OptionScene", 1.0f);
    }

    public void ChangeButton_rk()
    {
        FadeManager.Instance.LoadLevel("RankingScene",1.0f);
    }

    public void ChangeButton_rc()
    {
<<<<<<< HEAD
        FadeManager.Instance.LoadLevel("RuleCheckScene", 1.0f);
=======
        SceneManager.LoadScene("RuleScene");
>>>>>>> af7938f399ea491d8bc89415e9d22b3ede7d5527
    }

    public void ChangeButton_Ti()
    {
        FadeManager.Instance.LoadLevel("TitleScene", 1.0f);
    }

    public void EndGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
