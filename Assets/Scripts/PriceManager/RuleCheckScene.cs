using UnityEngine;
using UnityEngine.SceneManagement;

public class RuleCheckScene : MonoBehaviour
{
    [SerializeField] private AudioSource audiosource;
    [SerializeField] private AudioClip clip;
    [SerializeField] private AudioClip clip2;

    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }
    public void RuleYes()
    {
        SceneManager.LoadScene("RuleScene");
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
