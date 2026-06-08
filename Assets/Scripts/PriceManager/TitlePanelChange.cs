using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using NaughtyAttributes;

public class TitlePanelChange : MonoBehaviour
{
    //AudioManager.Instance.seSource.PlayOneShot(sound.Click);
    [SerializeField] private GameObject[] titlepanels;
    bool ispush = false;

    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeTime = 1f;
    [SerializeField, Scene] int[] sceneID;

    /*
     * 0,タイトルパネル
     * 1,チュートリアルチェックパネル
     * 2,モード選択パネル
     */
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
    }

    //シーン切り替え
    public void TutorialChecktoTutorialYES()
    {
        //チュートリアルシーンに移動
        SceneStatic.LoadScene(sceneID[0], fadeImage,fadeTime);
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
        SceneStatic.LoadScene(sceneID[1], fadeImage, fadeTime);
    }
    public void RoadTimeLimitScene()
    {
        if (ispush) return;

        ispush = true;
        SceneStatic.LoadScene(sceneID[2], fadeImage, fadeTime);
    }

}
