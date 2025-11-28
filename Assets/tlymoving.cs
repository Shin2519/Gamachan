using System.Collections;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class tlymoving : MonoBehaviour
{
    [SerializeField]
    private float speed;

    Vector2 leftPos = new Vector2(-700f,-300f);
    Vector2 rightPos = new Vector2(700f,-300f);

    RectTransform tlyPos;
    Vector2 Pos;
    private void Awake()
    {
        tlyPos = GetComponent<RectTransform>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(leftmove());
    }
    // Update is called once per frame
    void Update()
    {
        //Pos = tlyPos.position;
        //if(Pos.x==550)
        //{
        //    Pos.x -= speed * Time.deltaTime;
        //}
        //else if(Pos.x == -550)
        //{
        //    Pos.x += speed * Time.deltaTime;
        //}
        //tlyPos.position = Pos;
    }

    IEnumerator rightmove()
    {
        while(Pos.x <= 550)
        {
            Pos = tlyPos.position;
            Pos.x += speed * Time.deltaTime;
            tlyPos.position = Pos;
            yield return null;
            if (Pos.x <= 550)
            {
                StartCoroutine(leftmove());
            }
        }
    }
    IEnumerator leftmove()
    {
        while (Pos.x >= -550)
        {
            Pos = tlyPos.position;
            Pos.x -= speed * Time.deltaTime;
            tlyPos.position = Pos;
            yield return null;
            if(Pos.x >= -550)
            {
                StartCoroutine(rightmove());
            }
        }
    }
}
