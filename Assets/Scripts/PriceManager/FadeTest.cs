using UnityEngine;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeTest : MonoBehaviour
{
    [Scene, SerializeField,Header("シーンID")] int sceneId;
    [SerializeField,Header("フェード用イメージ")] Image image;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sceneId = SceneManager.GetActiveScene().buildIndex;
    }

    public void SceneChange()
    {
        image.DOFade(0f,1f);
        SceneManager.LoadScene(sceneId);
    }

}
