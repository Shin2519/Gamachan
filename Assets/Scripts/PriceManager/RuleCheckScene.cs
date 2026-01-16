using UnityEngine;
using UnityEngine.SceneManagement;

public class RuleCheckScene : MonoBehaviour
{
    [SerializeField] private AudioSource audiosource;
    [SerializeField] private AudioClip clip;
    [SerializeField] private AudioClip clip2;
    [SerializeField] private GameObject Page;

    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
        Page.SetActive(false);
    }
    public void RuleYes()
    {
        //FadeManager.Instance.LoadLevel("RuleScene",1f);
        this.gameObject.SetActive(false);
        Page.SetActive(true);
        audiosource.PlayOneShot(clip);
    }

    public void RuleNo()
    {
        SceneManager.LoadScene("ModeSelectScene");
        audiosource.PlayOneShot(clip);
    }

    public void Title()
    {
        SceneManager.LoadScene("TitleScene");
        audiosource.PlayOneShot(clip2);
    }
}
