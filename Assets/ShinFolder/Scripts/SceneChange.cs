using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using NaughtyAttributes;
using UnityEngine.UI;


public class SceneChange : MonoBehaviour
{

    [Header("オプションパネル")]
    public GameObject optionPanel;

    [SerializeField] private GameObject[] titlepanels;
    bool ispush = false;

    [SerializeField] private float fadeTime = 1f;

    [SerializeField] private GameObject startbutton;


    private void Start()
    {
        for (int i = 1; i < titlepanels.Length; i++)
        {
            titlepanels[i].SetActive(false);
        }
    }
    //パネル切り替え,チュートリアルチェック
    public void TitletoTutorialCheck()
    {
        titlepanels[1].SetActive(true);
        AudioManager.Instance.PlaySE(AudioManager.Instance.SE[0]);


    }

    //シーン切り替え
    public void TutorialChecktoTutorialYES()
    {
        FadeManager.Instance.LoadLevel(0, fadeTime);
        AudioManager.Instance.PlaySE(AudioManager.Instance.SE[0]);


    }

    //パネル切り替えモード選択
    public void TutorialChecktoTutorialNO()
    {
        titlepanels[1].SetActive(false);


        titlepanels[2].SetActive(true);
        AudioManager.Instance.PlaySE(AudioManager.Instance.SE[0]);



    }
    public void RoadCharengeScene()
    {
        if (ispush) return;

        ispush = true;
        FadeManager.Instance.LoadLevel(4,fadeTime);
        AudioManager.Instance.PlaySE(AudioManager.Instance.SE[2]);


    }

    public void ChangeButton_st()
    {
        startbutton.SetActive(false);
        optionPanel.SetActive(true);
        AudioManager.Instance.PlaySE(AudioManager.Instance.SE[0]);


    }
    public void ChangeButton_ti(GameObject obj)
    {
        startbutton.SetActive(true);
        obj.SetActive(false);
        AudioManager.Instance.PlaySE(AudioManager.Instance.SE[0]);


    }

    public void ChangeButton_rk()
    {
        FadeManager.Instance.LoadLevel(2, fadeTime);
        AudioManager.Instance.PlaySE(AudioManager.Instance.SE[0]);


    }

    public void ChangeButton_Ti()
    {
        FadeManager.Instance.LoadLevel(0, fadeTime);
        AudioManager.Instance.PlaySE(AudioManager.Instance.SE[1]);


    }

    public void EndGame()
    {
        Application.Quit();
        AudioManager.Instance.PlaySE(AudioManager.Instance.SE[0]);


    }
}
