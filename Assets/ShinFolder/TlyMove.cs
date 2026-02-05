using UnityEngine;

public class TlyMove : MonoBehaviour
{
    public float moveDistance = 200f;
    public float Speed = 2f;
    [SerializeField]
    private SendData total_deta;
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
                if (TouchPanel.instance.Onpay == true) return;
                TouchPanel.instance.InputAmount += 500;
                total_deta.total_Data.c500_count += 1;
            }
            else if (other.gameObject.name == "100yen(Clone)")
            {
                if (TouchPanel.instance.Onpay == true) return;
                TouchPanel.instance.InputAmount += 100;
                total_deta.total_Data.c100_count += 1;
            }
            else if (other.gameObject.name== "50yen(Clone)")
            {
                if (TouchPanel.instance.Onpay == true) return;
                TouchPanel.instance.InputAmount += 50;
                total_deta.total_Data.c50_count += 1;
            }
            else if (other.gameObject.name== "10yen(Clone)")
            {
                if (TouchPanel.instance.Onpay == true) return;
                TouchPanel.instance.InputAmount += 10;
                total_deta.total_Data.c10_count += 1;
            }
            else if(other.gameObject.name == "5yen(Clone)")
            {
                if (TouchPanel.instance.Onpay == true) return;
                TouchPanel.instance.InputAmount += 5;
                total_deta.total_Data.c5_count += 1;
            }
            else if (other.gameObject.name == "1yen(Clone)")
            {
                if (TouchPanel.instance.Onpay == true) return;
                TouchPanel.instance.InputAmount += 1;
                total_deta.total_Data.c1_count += 1;
            }
            other.gameObject.SetActive(false);
            other.gameObject.GetComponent<Collider2D>().enabled = false;

            if (TouchPanel.instance.InputAmount >= TouchPanel.instance.Total|| Gauge_State.gauge_state == Somethings_State.Gauge_State.Gold) return;

            UIManagement.instance.gauge();
        }
    }
}
