using UnityEngine;

public class TlyMove : MonoBehaviour
{
    public float moveDistance = 200f;
    public float Speed = 2f;

    private Transform pos;
    private Vector2 startPos;


    void Awake()
    {
        
    }
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
            if (other.gameObject.name=="500yen(Clone)")
            {
                TachPanel.instance.InputAmount += 500;
            }
            else if (other.gameObject.name == "100yen(Clone)")
            {
                TachPanel.instance.InputAmount += 100;
            }
            else if (other.gameObject.name== "50yen(Clone)")
            {
                TachPanel.instance.InputAmount += 50;
                Destroy(other.gameObject);
            }
            else if (other.gameObject.name== "10yen(Clone)")
            {
                TachPanel.instance. InputAmount += 10;
            }
            else if (other.gameObject.name== "1yen(Clone)")
            {
                TachPanel.instance.InputAmount += 1;
            }
            Destroy(other.gameObject);
        }
    }
}
