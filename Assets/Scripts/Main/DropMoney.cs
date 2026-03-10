using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DropMoney : GAMACHAN
{
    public static DropMoney instance;
    void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(St());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
