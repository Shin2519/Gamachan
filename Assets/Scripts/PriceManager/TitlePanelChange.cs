using UnityEngine;
using UnityEngine.SceneManagement;

public class TitlePanelChange : MonoBehaviour
{
    [SerializeField]
    private Sound sound;
    //AudioManager.Instance.seSource.PlayOneShot(sound.Click);
    [SerializeField] private GameObject[] titlepanels;
    /*
     * チャレンジモードとタイムリミットモードの選択方法
     * フラグを立てる
     */
    Mode mode;
    private void Start()
    {
        for (int i = 1; i < titlepanels.Length; i++)
        {
            titlepanels[i].SetActive(false);
        }
    }

    //パネル切り替え
    public void TitletoTutorialCheck()
    {

    }

    //シーン切り替え
    public void TutorialChecktoTutorialYES()
    {

    }

    //パネル切り替えモード選択
    public void TutorialChecktoTutorialNO()
    {

    }
}
