using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class SceneChange : MonoBehaviour
{
    [SerializeField]
    private Sound sound;
    
    [Header("オプションパネル")]
    public GameObject optionPanel;

    [SerializeField] private Scene[] scene;

    public GameObject Canvace1;
    public GameObject Canvace2;

    private void Start()
    {
        
    }

    public void ChangeButton_st()
    {
        optionPanel.SetActive(true);
    }

    public void ChangeButton_rk()
    {
        FadeManager.Instance.LoadLevel("RankingScene", 1.0f, null, null);
    }

    public void ChangeButton_rc()
    {
        AudioManager.Instance.seSource.PlayOneShot(sound.Click);
        FadeManager.Instance.LoadLevel("RuleScene", 1.0f, null, null);
    }

    public void ChangeButton_Ti()
    {
        FadeManager.Instance.LoadLevel("TitleScene", 1.0f, null, null);
    }
    public void ChangeButton_This()
    {
        FadeManager.Instance.LoadLevel("ChallengeModeScene", 1.0f, null, null);
    }

    public void ChangeButton_cr1()
    {

    }

    public void ChangeButton_cr2()
    {

    }


    public void EndGame()
    {
        Application.Quit();
    }
}
