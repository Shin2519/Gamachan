using UnityEngine;
<<<<<<< HEAD
using UnityEditor.SceneManagement;
=======
>>>>>>> 80745dc8801b4a9a2f5b2f97d73d17c34fc0a3e3
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
<<<<<<< HEAD
=======

    public void Title()
    {
        SceneManager.LoadScene("TitleScene");
    }
>>>>>>> 80745dc8801b4a9a2f5b2f97d73d17c34fc0a3e3
}
