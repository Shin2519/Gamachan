using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Text_control : MonoBehaviour
{
    public float scaleMin = 0.95f;//小さくする量
    public float scaleMax = 1.05f;//多きする量
    public float speed = 1f;      //脈動の速度(小さいほどゆっくり)

    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        //0～1の値をゆっくり繰り返す
        float t = (Mathf.Sin(Time.time * speed) + 1f) / 2f;
        //補間してスケールを決める
        float scale = Mathf.Lerp(scaleMin,scaleMax, t);
        transform.localScale = originalScale * scale;
    }
}
