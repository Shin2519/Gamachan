using UnityEngine;
using UnityEngine.SceneManagement;
public class RuleScene : MonoBehaviour
{
    public void TitleButton()
    {
       SceneManager.LoadScene("TitleScene");
    }
    public void ModeSelectButton()
    {
       SceneManager.LoadScene("ModeSelectScene");
    }
}
