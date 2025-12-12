using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject fadeout;
    public GameObject fadeCanvas;

    void Start()
    {
        if (!FadeManager.isFadeInstance)
        {
            Instantiate(fadeout);
        }
        Invoke("findFadeObject", 0.02f);
    }

    void findFadeObject()
    {
        fadeCanvas = GameObject.FindGameObjectWithTag("Fade");//canvas‚ðŒ©‚Â‚¯‚é
        fadeCanvas.GetComponent<FadeManager>().fadeIn();
    }

    public async void sceneChange_Rl()
    {
        fadeCanvas.GetComponent<FadeManager>().fadeOut();
        await Task.Delay(200);//ˆÃ“]‚·‚é‚Ü‚Å‘Ò‚Â
        SceneManager.LoadScene("RuleCheckScene");
    }

    public async void sceneChange_ST()
    {
        fadeCanvas.GetComponent<FadeManager>().fadeOut();
        await Task.Delay(200);//ˆÃ“]‚·‚é‚Ü‚Å‘Ò‚Â
        SceneManager.LoadScene("OptionScene");
    }

    public async void sceneChange_Rk()
    {
        fadeCanvas.GetComponent<FadeManager>().fadeOut();
        await Task.Delay(200);//ˆÃ“]‚·‚é‚Ü‚Å‘Ò‚Â
        SceneManager.LoadScene("RankingScene");
    }

    public async void sceneChange_Tl()
    {
        fadeCanvas.GetComponent<FadeManager>().fadeOut();
        await Task.Delay(200);//ˆÃ“]‚·‚é‚Ü‚Å‘Ò‚Â
        SceneManager.LoadScene("TitleScene");
    }

    public void EndGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
