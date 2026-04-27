using UnityEngine;

public class TlyMove : MasterCode
{
    public float moveDistance = 200f;
    public float Speed = 2f;
    private Transform pos;
    private Vector2 startPos;

    [SerializeField, Header("位置調整")]
    Vector2 offset;
    [SerializeField, Header("サイズ調整")]
    Vector2 offset2;
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
        int GamaGuti = other.gameObject.GetComponent<playercontroll>().GamaNum;
        if(GamaGuti==1)return;
        other.gameObject.SetActive(false);
        other.gameObject.GetComponent<Collider2D>().enabled = false;
        if (Onpay||ResultPanel.activeSelf) return;
        int itsMoney = other.gameObject.GetComponent<FallMoney>().MyMoney;
        AudioManager.Instance.seSource.PlayOneShot(sound.CoinFall);
        if (itsMoney==500|| itsMoney == 100|| itsMoney == 50|| itsMoney == 10|| itsMoney == 5|| itsMoney == 1)
        {
            Register.register.InputAmount += itsMoney;
            switch(itsMoney)
            {
                case 1:
                    Data.total_Data.c1_count += 1;
                    break;
                case 5:
                    Data.total_Data.c5_count += 1;
                    break;
                case 10:
                    Data.total_Data.c10_count += 1;
                    break;
                case 50:
                    Data.total_Data.c50_count += 1;
                    break;
                case 100:
                    Data.total_Data.c100_count += 1;
                    break;
                case 500:
                    Data.total_Data.c500_count += 1;
                    break;
            }
        }
        if (Register.register.InputAmount >= Register.register.Total || gauge_state == State.Gauge.Gold) return;

        UIManagement.uimanagement.gauge();
    }
}
