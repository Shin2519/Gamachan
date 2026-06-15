using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using NaughtyAttributes;
using UnityEngine.UI;


public class SceneChange : MonoBehaviour
{
    [SerializeField]
    private Sound sound;

    [Header("オプションパネル")]
    public GameObject optionPanel;

    [SerializeField] private GameObject[] titlepanels;
    bool ispush = false;

    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeTime = 1f;

    [SerializeField] private GameObject startbutton;


    private void Start()
    {
        for (int i = 1; i < titlepanels.Length; i++)
        {
            titlepanels[i].SetActive(false);
        }
        DontDestroyOnLoad(gameObject);
    }
    //パネル切り替え,チュートリアルチェック
    public void TitletoTutorialCheck()
    {
        titlepanels[1].SetActive(true);
    }

    //シーン切り替え
    public void TutorialChecktoTutorialYES()
    {
        SceneStatic.LoadScene(0, fadeImage, fadeTime);
    }

    //パネル切り替えモード選択
    public void TutorialChecktoTutorialNO()
    {
        titlepanels[1].SetActive(false);


        titlepanels[2].SetActive(true);

    }
    public void RoadCharengeScene()
    {
        if (ispush) return;

        ispush = true;
        SceneStatic.LoadScene(4, fadeImage, fadeTime);
    }

    public void ChangeButton_st()
    {
        startbutton.SetActive(false);
        optionPanel.SetActive(true);
        
    }
    public void ChangeButton_ti(GameObject obj)
    {
        startbutton.SetActive(true);
        obj.SetActive(false);

    }

    public void ChangeButton_rk()
    {
        SceneStatic.LoadScene(2, fadeImage, fadeTime);
    }

    public void ChangeButton_Ti()
    {
        SceneStatic.LoadScene(0, fadeImage, fadeTime);
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
