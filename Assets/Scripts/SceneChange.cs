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
        SceneManager.LoadScene("SettingScene");
    }

    public void ChangeButton_rk()
    {
        SceneManager.LoadScene("RankingScene");
    }

    public void ChangeButton_rc()
    {
        SceneManager.LoadScene("RuleCheckScene");
    }

    public void EndGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
