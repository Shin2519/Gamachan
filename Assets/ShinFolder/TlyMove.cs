using UnityEngine;

public class TlyMove : MonoBehaviour
{
    [SerializeField]
    private Sound sound;
    public float moveDistance = 200f;
    public float Speed = 2f;
    [SerializeField]
    private SendData total_deta;
    [SerializeField]
    private Somethings_State Gauge_State;
    [SerializeField]
    SendTotalData sendtotaldata;
    private Transform pos;
    private Vector2 startPos;

    [SerializeField, Header("位置調整")]
    Vector2 offset;
    [SerializeField, Header("サイズ調整")]
    Vector2 offset2;

    [SerializeField]
    private GameObject Panel;
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
        other.gameObject.SetActive(false);
        other.gameObject.GetComponent<Collider2D>().enabled = false;
        if (TouchPanel.instance.Onpay||Panel.activeSelf) return;
        int itsMoney = other.gameObject.GetComponent<FallMoney>().MyMoney;
        AudioManager.Instance.seSource.PlayOneShot(sound.CoinFall);
        if (itsMoney==500|| itsMoney == 100|| itsMoney == 50|| itsMoney == 10|| itsMoney == 5|| itsMoney == 1)
        {
            TouchPanel.instance.InputAmount += itsMoney;
            switch(itsMoney)
            {
                case 1:
                    total_deta.total_Data.c1_count += 1;
                    break;
                case 5:
                    total_deta.total_Data.c5_count += 1;
                    break;
                case 10:
                    total_deta.total_Data.c10_count += 1;
                    break;
                case 50:
                    total_deta.total_Data.c50_count += 1;
                    break;
                case 100:
                    total_deta.total_Data.c100_count += 1;
                    break;
                case 500:
                    total_deta.total_Data.c500_count += 1;
                    break;
            }
        }
        if (TouchPanel.instance.InputAmount >= TouchPanel.instance.Total || Gauge_State.gauge_state == Somethings_State.Gauge_State.Gold) return;

        UIManagement.instance.gauge();
    }
}
