using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    public static bool isFadeInstance = false;

    public bool isFadein = false;
    public bool isFadeout = false;

    public float alpha = 0.0f;//“§‰ß—¦
    public float fadeSpeed = 0.2f;

    void Start()
    {
        if(!isFadeInstance)
        {
            DontDestroyOnLoad(this);
            isFadeInstance = true;
        }
        else
        {
            Destroy(this);
        }
    }

    void Update()
    {
        if(isFadein)
        {
            alpha -= Time.deltaTime / fadeSpeed;
            if(alpha<=0.0f)
            {
                isFadein = false;
                alpha = 0.0f;
            }
            this.GetComponentInChildren<Image>().color = new Color(0.0f, 0.0f, 0.0f, alpha);
        }
        else if(isFadeout)
        {
            alpha += Time.deltaTime / fadeSpeed;
            if(alpha>=1.0f)
            {
                isFadeout = false;
                alpha = 1.0f;
            }
            this.GetComponentInChildren<Image>().color = new Color(0.0f, 0.0f, 0.0f, alpha);
        }
    }

    public void fadeIn()
    {
        isFadein=true;
        isFadeout=false;
    }

    public void fadeOut()
    {
        isFadeout = true;
        isFadein = false;
    }
}
