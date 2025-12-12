using UnityEngine;

public class Raincoin : MonoBehaviour
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
            ResetPosition();
        }
    }

    void ResetPosition()
    {
        float randomX = Random.Range(-800f, 800f);
        rect.anchoredPosition = new Vector2(randomX, resetY);
    }
}
