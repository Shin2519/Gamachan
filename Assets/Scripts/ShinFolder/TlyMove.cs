using UnityEngine;

public class TlyMove : MonoBehaviour
{
    public float moveDistance = 200f;
    public float Speed = 2f;

    private Transform pos;
    private Vector2 startPos;

    void Start()
    {
        pos = GetComponent<Transform>();
        startPos = pos.position;
    }
    void Update()
    {
        float x = Mathf.Sin(Time.time * Speed) * moveDistance;
        pos.position = new Vector2(startPos.x+x,startPos.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
        }
    }
}
