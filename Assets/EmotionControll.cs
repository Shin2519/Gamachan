using UnityEngine;
using UnityEngine.UI;

public class EmotionControll : MonoBehaviour
{
    [SerializeField, Header("Gama")]
    GameObject Gama;
    Image Gama_Image;
    [SerializeField, Header("GamaÇÃä¥èÓ")]
    Sprite[] KindofEmotion;
    float time;
    [SerializeField]
    float Start_time;
    void Awake()
    {
        Gama_Image = Gama.GetComponent<Image>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        time = Start_time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Gama_Image.sprite != KindofEmotion[0])
        {
            time--;
            if(time==0)
            {
                Gama_Image.sprite = KindofEmotion[0];
                time = Start_time;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Coin"))
        {
            time = Start_time;
            Vector2 Dir = (col.gameObject.transform.position - transform.position).normalized;
            float Dot = Vector2.Dot(Dir,transform.up);
            Debug.Log(Dot);
            if(Dot > 0.9f)
            {
                Gama_Image.sprite = KindofEmotion[1];
            }
            else
            {
                Gama_Image.sprite = KindofEmotion[2];
            }
        }
    }
}
