using UnityEngine;
using System;

public class Coin : MonoBehaviour
{
    [SerializeField, Header("初速度")]
    private float v0;

    [SerializeField, Header("金額")]
    private int yen;

    public int Yen => yen;

    Action<Coin> onReturn;
    public void Initialize(Action<Coin> onReturn)
    {
        this.onReturn = onReturn;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Gamatyan")) return;
        if (col.gameObject.CompareTag("Tray"))
        {
            onReturn?.Invoke(this);
        }
    }
}
