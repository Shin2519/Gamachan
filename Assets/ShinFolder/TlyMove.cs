using UnityEngine;

public class TlyMove : MonoBehaviour
{
    public float moveDistance = 200f;
    public float Speed = 2f;
    [SerializeField]
    private Somethings_State Gauge_State;
    private Transform pos;
    private Vector2 startPos;

    [SerializeField,Header("効果音")]
    private AudioClip coinFall;

    AudioSource audioSource;

    [SerializeField, Header("位置調整")]
    Vector2 offset;
    [SerializeField, Header("サイズ調整")]
    Vector2 offset2;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        //pos = GetComponent<Transform>();
        transform.localPosition = offset;
        transform.localScale = offset2;
        //startPos = pos.position;
    }
    void Update()
    {
        //float x = Mathf.Sin(Time.time * Speed) * moveDistance;
        //pos.position = new Vector2(startPos.x+x,startPos.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            audioSource.PlayOneShot(coinFall);
            if (other.gameObject.name=="500yen(Clone)")
            {
                TouchPanel.instance.InputAmount += 500;
            }
            else if (other.gameObject.name == "100yen(Clone)")
            {
                TouchPanel.instance.InputAmount += 100;
            }
            else if (other.gameObject.name== "50yen(Clone)")
            {
                TouchPanel.instance.InputAmount += 50;
            }
            else if (other.gameObject.name== "10yen(Clone)")
            {
                TouchPanel.instance.InputAmount += 10;
            }
            else if(other.gameObject.name == "5yen(Clone)")
            {
                TouchPanel.instance.InputAmount += 5;
            }
            else if (other.gameObject.name == "1yen(Clone)")
            {
                TouchPanel.instance.InputAmount += 1;
            }
            other.gameObject.SetActive(false);

            if (TouchPanel.instance.InputAmount >= TouchPanel.instance.Total|| Gauge_State.gauge_state == Somethings_State.Gauge_State.Gold) return;

            UIManagement.instance.gauge();
        }
    }
}
