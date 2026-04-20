using UnityEngine;
using System.Collections;
using System;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class FadeManager : SingletonMonoBehaviour<FadeManager>//singleはどこのスクリプトからでも呼べるようにするため
{
    private Texture2D blackTexture;//暗転用
    private float fadeAlpha = 0;//フェード中の透明度
    private bool isFadeing = false;//フェード中かどうか

    public void Awake()
    {
        if(this != Instance)
        {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(this.gameObject);

        //黒テクスチャを作る
        this.blackTexture = new Texture2D(1, 1);
        this.blackTexture.SetPixel(0, 0, Color.black);
        this.blackTexture.Apply();

    }

    public void OnGUI()
    {
        if (!this.isFadeing) return;

        GUI.color = new Color(0, 0, 0, this.fadeAlpha);
        GUI.DrawTexture(
            new Rect(0, 0, Screen.width, Screen.height),
            this.blackTexture
        );
    }



    public void LoadLevel(string scene,float interval)
    {
        StartCoroutine(TransScene(scene,interval));
    }

    private IEnumerator TransScene(string scene,float interval)
    {
        //だんだん暗く
        this.isFadeing = true;
        float time = 0;
        while(time<=interval)
        {
            this.fadeAlpha = Mathf.Lerp(0f, 1f, time / interval);
            time += Time.deltaTime;
            yield return 0;
        }

        //シーンの切り替え
        SceneManager.LoadScene(scene);


        //だんだん明るく
        time = 0;
        while(time<=interval)
        {
            this.fadeAlpha = Mathf.Lerp(1f, 0f, time / interval);
            time += Time.deltaTime;
            yield return 0;
        }

        this.isFadeing = false;
    }
}
