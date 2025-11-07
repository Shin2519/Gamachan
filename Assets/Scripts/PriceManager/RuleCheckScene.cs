using UnityEngine;
using UnityEngine.SceneManagement;

public class RuleCheckScene : MonoBehaviour
{
    public void RuleYes()
    {
        SceneManager.LoadScene("RuleScene");
    }

    public void RuleNo()
    {
        SceneManager.LoadScene("ModeSelectScene");
    }

    public void Title()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
