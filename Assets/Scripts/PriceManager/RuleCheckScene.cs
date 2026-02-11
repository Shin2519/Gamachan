using UnityEngine;
using UnityEngine.SceneManagement;

public class RuleCheckScene : MonoBehaviour
{
    [SerializeField] private Sound sound;
    [SerializeField] private GameObject Page;

    private void Start()
    {
        Page.SetActive(false);
    }
    public void RuleYes()
    {
        //FadeManager.Instance.LoadLevel("RuleScene",1f);
        this.gameObject.SetActive(false);
        Page.SetActive(true);
        AudioManager.Instance.seSource.PlayOneShot(sound.Click);
    }

    public void RuleNo()
    {
        SceneManager.LoadScene("ModeSelectScene");
        AudioManager.Instance.seSource.PlayOneShot(sound.Click);
    }

    public void Title()
    {
        SceneManager.LoadScene("TitleScene");
        AudioManager.Instance.seSource.PlayOneShot(sound.Back);
    }
}
