using UnityEngine;
using UnityEngine.SceneManagement;

public class TitlePanelChange : MonoBehaviour
{
    [SerializeField]
    private Sound sound;
    //AudioManager.Instance.seSource.PlayOneShot(sound.Click);
    [SerializeField] private GameObject[] titlepanels;
    bool ispush = false;

    /*
     * 0,タイトルパネル
     * 1,チュートリアルチェックパネル
     * 2,モード選択パネル
     */
    Mode mode;
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
        Fade.Instance.FadeScenChenge(1);
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
        Fade.Instance.FadeScenChenge(5);

    }
    public void RoadTimeLimitScene()
    {
        if (ispush) return;

        ispush = true;
        Fade.Instance.FadeScenChenge(3);
    }

}
