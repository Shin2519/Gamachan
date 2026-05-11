using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeSelectScene : MonoBehaviour
{
    [SerializeField]
    private Sound sound;
    /*
     * チャレンジモードとタイムリミットモードの選択方法
     * フラグを立てる
     */
    Mode mode;

    public void CharengeButton()
    {
        AudioManager.Instance.seSource.PlayOneShot(sound.Click);
        FadeManager.Instance.LoadLevel("InputNameScene", 1.0f, null, null);
        Mode.Instance.isMode = true;
    }

    public void TimeLimitButton()
    {
        AudioManager.Instance.seSource.PlayOneShot(sound.Click);
        FadeManager.Instance.LoadLevel("InputNameScene", 1.0f, null, null);
        Mode.Instance.isMode = false;
    }

    public void Title()
    {
        AudioManager.Instance.seSource.PlayOneShot(sound.Back);
        FadeManager.Instance.LoadLevel("TitleScene", 1.0f, null, null);
    }
}
