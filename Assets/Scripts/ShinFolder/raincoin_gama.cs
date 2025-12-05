using UnityEngine;

public class raincoin_gama : MonoBehaviour
{
    public float speed = 1000f;
    public float resetY = 600f;
    public float endY = -600f;

    RectTransform rect;

    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    void Update()
    {
        //‰º•ûŒü‚ÉˆÚ“®
        rect.anchoredPosition += Vector2.down * speed * Time.deltaTime;
        //ˆê’è‚æ‚è‰º‚És‚Á‚½‚çã‚É–ß‚·
        if (rect.anchoredPosition.y < endY)
        {
            Destroy(gameObject);
        }
    }
}