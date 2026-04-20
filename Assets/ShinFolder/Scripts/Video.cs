using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class Video : MonoBehaviour
{
    public float idleTimeout = 30f;
    private float timeElapsed = 0f;
    public CanvasGroup canvasGroup;

    public VideoPlayer videoPlayer;


    void Start()
    {
        if(videoPlayer != null)
        {
            canvasGroup.alpha = 0;
            videoPlayer.loopPointReached += OnVideoEnd;
            videoPlayer.Prepare();
        }
        timeElapsed = 0f;
    }

    void Update()
    {
        if(Input.anyKeyDown||Input.GetMouseButton(0)||Input.GetMouseButton(1)||Input.GetMouseButton(2))
        {
            timeElapsed = 0f;
        }
        if(Input.touchCount>0)
        {
            timeElapsed = 0f;
        }

        timeElapsed += Time.deltaTime;

        if(timeElapsed>=idleTimeout)
        {
            TransitionToVideoOrScene();
            timeElapsed = 0f;
        }
    }

    void TransitionToVideoOrScene()
    {
        if(videoPlayer != null)
        {
            Debug.Log("ŽžŠÔŒo‰ß");
            canvasGroup.alpha = 1f;
            videoPlayer.Play();
        }
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene("TitleScene");
    }
}
