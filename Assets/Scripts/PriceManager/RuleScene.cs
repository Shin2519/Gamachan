using UnityEngine;
using UnityEngine.SceneManagement;
public class RuleScene : MonoBehaviour
{
    [SerializeField] private GameObject Page1;
    [SerializeField] private GameObject Page2;
    [SerializeField] private GameObject Page3;
    private AudioSource audiosource;
    [SerializeField] private AudioClip clip;

    private void Start()
    {
        Page1.SetActive(false);
        Page2.SetActive(false);
        Page3.SetActive(false);
        audiosource = GetComponent<AudioSource>();
    }


    public void TitleButton()
    {
       SceneManager.LoadScene("TitleScene");
    }
    public void ModeSelectButton()
    {
       SceneManager.LoadScene("ModeSelectScene");
    }

    public void Page1to2()
    {
        Page1.SetActive(false);
        Page2.SetActive(true);
        audiosource.PlayOneShot(clip);
    }

    public void Page2to1()
    {
        Page1.SetActive(true);
        Page2.SetActive(false);
        audiosource.PlayOneShot(clip);
    }

    public void Page2to3()
    {
        Page2.SetActive(false);
        Page3.SetActive(true);
        audiosource.PlayOneShot(clip);
    }

    public void Page3to2()
    {
        Page2.SetActive(true);
        Page3.SetActive(false);
        audiosource.PlayOneShot(clip);
    }
}
