using UnityEngine;

public class TlyMove : MonoBehaviour
{
    public float moveDistance = 200f;
    public float Speed = 2f;

    private RectTransform rectTransform;
    private Vector2 startPos;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        startPos = rectTransform.anchoredPosition;
    }

    void Update()
    {
        float x = Mathf.Sin(Time.time * Speed) * moveDistance;
        rectTransform.anchoredPosition = new Vector2(startPos.x+x,startPos.y);
    }
}
