using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeSelectScene : MonoBehaviour
{

    /*
     * チャレンジモードとタイムリミットモードの選択方法
     * フラグを立てる
     */
    Mode mode;

    public void CharengeButton()
    {
        SceneManager.LoadScene("ChallengeModeScene");
        Mode.Instance.isMode = true;
    }

    public void TimeLimitButton()
    {
        SceneManager.LoadScene("InputNameScene");
        Mode.Instance.isMode = false;
    }

    public void Title()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
