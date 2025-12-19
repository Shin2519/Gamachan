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
<<<<<<< HEAD
        FadeManager.Instance.LoadLevel("ChallengeModeScene", 1.0f);
=======
        SceneManager.LoadScene("InputNameScene");
>>>>>>> af7938f399ea491d8bc89415e9d22b3ede7d5527
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
