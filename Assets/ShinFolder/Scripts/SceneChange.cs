using UnityEngine;
using UnityEngine.SceneManagement;



public class SceneChange : MonoBehaviour
{


    [SerializeField] private GameObject[] titlepanels;
    bool ispush = false;

    [SerializeField] private float fadeTime;



    private void Start()
    {
        for (int i = 1; i < titlepanels.Length; i++)
        {
            titlepanels[i].SetActive(false);
        }
    }

    public void RoadCharengeScene()
    {
        if (ispush) return;
        AudioManager.Instance.PlaySE(AudioManager.Instance.SE[2]);
        FadeManager.Instance.LoadLevel(2,fadeTime);
        ispush = true;
    }

    public void ChangeButton_true(GameObject obj)
    {
        AudioManager.Instance.PlaySE(AudioManager.Instance.SE[0]);
        obj.SetActive(true);
    }

    
    public void ChangeButton_false(GameObject obj)
    {
        AudioManager.Instance.PlaySE(AudioManager.Instance.SE[0]);
        obj.SetActive(false);
    }

    public void PoseButtonTrue(GameObject obj)
    {
        Time.timeScale = 0;
        AudioManager.Instance.PlaySE(AudioManager.Instance.SE[0]);
        obj.SetActive(true);
    }

    public void PoseButtonFalse(GameObject obj)
    {
        Time.timeScale = 1;
        AudioManager.Instance.PlaySE(AudioManager.Instance.SE[0]);
        obj.SetActive(false);
    }

    public void ChangeButton_rk()
    {
        AudioManager.Instance.PlaySE(AudioManager.Instance.SE[0]);
        FadeManager.Instance.LoadLevel(1, fadeTime);
    }

    public void ChangeButton_Ti()
    {
        Time.timeScale = 1;
        AudioManager.Instance.PlaySE(AudioManager.Instance.SE[2]);
        FadeManager.Instance.LoadLevel(0, fadeTime);
    }

    public void EndGame()
    {
        AudioManager.Instance.PlaySE(AudioManager.Instance.SE[0]);
        Application.Quit();
    }
}
