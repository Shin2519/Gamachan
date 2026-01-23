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
        FadeManager.Instance.LoadLevel("InputNameScene", 1.0f);
        Mode.Instance.isMode = true;
    }

    public void TimeLimitButton()
    {
        FadeManager.Instance.LoadLevel("InputNameScene", 1.0f);
        Mode.Instance.isMode = false;
    }

    public void Title()
    {
        FadeManager.Instance.LoadLevel("TitleScene", 1.0f);
    }
}
