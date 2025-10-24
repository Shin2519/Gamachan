using UnityEngine;
using UnityEngine.SceneManagement;
public class RuleScene : MonoBehaviour
{
<<<<<<< HEAD
=======
    [SerializeField] private GameObject Page1;
    [SerializeField] private GameObject Page2;
    [SerializeField] private GameObject Page3;

    private void Start()
    {
        Page1.SetActive(true);
        Page2.SetActive(false);
        Page3.SetActive(false);
    }


>>>>>>> 80745dc8801b4a9a2f5b2f97d73d17c34fc0a3e3
    public void TitleButton()
    {
       SceneManager.LoadScene("TitleScene");
    }
    public void ModeSelectButton()
    {
       SceneManager.LoadScene("ModeSelectScene");
    }
<<<<<<< HEAD
=======

    public void Page1to2()
    {
        Page1.SetActive(false);
        Page2.SetActive(true);
    }

    public void Page2to1()
    {
        Page1.SetActive(true);
        Page2.SetActive(false);
    }

    public void Page2to3()
    {
        Page2.SetActive(false);
        Page3.SetActive(true);
    }

    public void Page3to2()
    {
        Page2.SetActive(true);
        Page3.SetActive(false);
    }
>>>>>>> 80745dc8801b4a9a2f5b2f97d73d17c34fc0a3e3
}
