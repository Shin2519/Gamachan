using UnityEngine;
using System;

public class Coin : MonoBehaviour
{
    [SerializeField, Header("‰‘¬“x")]
    private float v0;

    [SerializeField, Header("‹àŠz")]
    private int yen;

    public int Yen => yen;

    Action<Coin> onReturn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
