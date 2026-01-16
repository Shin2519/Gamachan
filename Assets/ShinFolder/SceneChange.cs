using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField] private string SettingScene;
    [SerializeField] private string RankingScene;
    [SerializeField] GameObject Pose;

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
        FadeManager.Instance.LoadLevel("RuleScene", 1.0f);
    }

    public void ChangeButton_Ti()
    {
        FadeManager.Instance.LoadLevel("TitleScene", 1.0f);
    }
    public void OnPose()
    {
        Pose.SetActive(true);
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
