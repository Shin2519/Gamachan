using UnityEngine;

public class tlymoving : MonoBehaviour
{
    [SerializeField]
    private float speed;

    Vector2 leftPos = new Vector2(-700f,-300f);
    Vector2 rightPos = new Vector2(700f,-300f);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RectTransform tlyPos = GetComponent<RectTransform>();
        Vector2 Pos = tlyPos.position;
        Pos.x += speed * Time.deltaTime;
        tlyPos.position = Pos;
    }
}
