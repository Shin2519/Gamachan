using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
public static class SceneStatic
{ 
    public static void LoadScene(int index,Image fadeimage,float fadeTime)
    {
        //暗く
        fadeimage.color = new Color(0, 0, 0, 0);

        fadeimage
            .DOFade(1.0f, fadeTime)
            .OnComplete(() =>
            {
                SceneManager.GetSceneByBuildIndex(index);

                //明るく
                fadeimage.color = new Color(0, 0, 0, 1);

                fadeimage.DOFade(0f, fadeTime);
                    
            });

    }

}
