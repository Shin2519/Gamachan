using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using NaughtyAttributes;
using UnityEngine.UI;


public class SceneChange : MonoBehaviour
{


    [SerializeField] private GameObject[] titlepanels;
    bool ispush = false;

    [SerializeField] private float fadeTime = 1f;



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
        AudioManager.Instance.PlaySE(AudioManager.Instance.SE[0]);
        titlepanels[1].SetActive(true);
    }

    //シーン切り替え
    public void TutorialChecktoTutorialYES()
    {
        AudioManager.Instance.PlaySE(AudioManager.Instance.SE[0]);
        FadeManager.Instance.LoadLevel(0, fadeTime);

    }

    //パネル切り替えモード選択
    public void TutorialChecktoTutorialNO()
    {
        AudioManager.Instance.PlaySE(AudioManager.Instance.SE[0]);
        titlepanels[1].SetActive(false);

        titlepanels[2].SetActive(true);

    }
    public void RoadCharengeScene()
    {
        if (ispush) return;
        AudioManager.Instance.PlaySE(AudioManager.Instance.SE[2]);
        ispush = true;
        FadeManager.Instance.LoadLevel(2,fadeTime);
    }

    public void ChangeButton_true(GameObject obj)
    {
        AudioManager.Instance.PlaySE(AudioManager.Instance.SE[0]);
        obj.SetActive(true);
    }
    public void ChangeButton_false(GameObject obj)
    {
        AudioManager.Instance.PlaySE(AudioManager.Instance.SE[0]);
        obj.SetActive(false);
    }

    public void ChangeButton_rk()
    {
        AudioManager.Instance.PlaySE(AudioManager.Instance.SE[0]);
        FadeManager.Instance.LoadLevel(1, fadeTime);
    }

    public void ChangeButton_Ti()
    {
        AudioManager.Instance.PlaySE(AudioManager.Instance.SE[2]);
        FadeManager.Instance.LoadLevel(0, fadeTime);

    }

    public void EndGame()
    {
        AudioManager.Instance.PlaySE(AudioManager.Instance.SE[0]);
        Application.Quit();
    }
}
