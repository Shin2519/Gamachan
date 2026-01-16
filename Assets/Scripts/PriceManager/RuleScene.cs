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
       FadeManager.Instance.LoadLevel("TitleScene", 1.0f);
    }
    public void ModeSelectButton()
    {
       FadeManager.Instance.LoadLevel("ModeSelectScene", 1.0f);
    }

    public void Page1to2()
    {
        //audiosource.PlayOneShot(clip);
        Page1.SetActive(false);
        Page2.SetActive(true);
        
    }

    public void Page2to1()
    {
        //audiosource.PlayOneShot(clip);
        Page1.SetActive(true);
        Page2.SetActive(false);
        
    }

    public void Page2to3()
    {
        //audiosource.PlayOneShot(clip);
        Page2.SetActive(false);
        Page3.SetActive(true);
        
    }

    public void Page3to2()
    {
        //audiosource.PlayOneShot(clip);
        Page2.SetActive(true);
        Page3.SetActive(false);
        
    }
}
