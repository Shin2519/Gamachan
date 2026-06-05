using DG.Tweening;
using DG.Tweening.Core.Easing;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public static Fade Instance {  get; private set; }

    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeTime = 1f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        if (fadeImage == null) return;
    }

    public void FadeScenChenge(int sceneID)
    {
        bool ispush = false;
        if (ispush) return;
        ispush= true;
        //ˆÃ‚­
        fadeImage.color = new Color(0, 0, 0, 0);

        fadeImage
            .DOFade(1, fadeTime)
            .OnComplete(() =>
            {
                SceneManager.LoadScene(sceneID);

                //–¾‚é‚­
                fadeImage.color = new Color(0, 0, 0, 1);

                fadeImage
                    .DOFade(0f, fadeTime)
                    .OnComplete(() =>
                    {
                        ispush = false;
                    });
            });
        
    }

    
}
