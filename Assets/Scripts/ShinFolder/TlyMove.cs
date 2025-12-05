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
            UIManagement.instance.gauge();
            if (other.gameObject.name=="500yen")
            {
                Debug.Log("500");
                TachPanel.instance.inputamount += 500;
            }
            else if (other.gameObject.name == "100yen")
            {
                TachPanel.instance.inputamount += 100;
            }
            else if (other.gameObject.name=="50yen")
            {
                TachPanel.instance.inputamount += 50;
                Debug.Log("50");
            }
            else if (other.gameObject.name=="10yen")
            {
                TachPanel.instance. inputamount += 10;
            }
            else if (other.gameObject.name=="1yen")
            {
                TachPanel.instance.inputamount += 1;
                Debug.Log("1");
            }
            Destroy(other.gameObject);
        }
    }
}
