using UnityEngine;
using System.Collections;

public class rankingchange: MonoBehaviour
{
    [SerializeField]
    GameObject timecanvas;
    [SerializeField]
    GameObject challengecanvas;

    [SerializeField]
    float duration = 0.5f;

    bool isFlipping = false;

    RectTransform t_canvas;

    RectTransform c_canvas;
    void Start()
    {
        // 最初は A を表示、B を非表示
        timecanvas.SetActive(false);
        challengecanvas.SetActive(true);

        c_canvas = challengecanvas.GetComponent<RectTransform>();
        c_canvas.transform.localRotation = Quaternion.identity;

        t_canvas = timecanvas.GetComponent<RectTransform>();
        t_canvas.transform.localRotation = Quaternion.Euler(0, 180, 0);// 裏向きで待機
    }

    public void FlipToCanvasB()
    {
        if (isFlipping) return;
        AudioManager.Instance.PlaySE(AudioManager.Instance.SE[0]);
        StartCoroutine(Flip(timecanvas, challengecanvas));
        
    }

    public void FlipToCanvasA()
    {
        if (isFlipping) return;
        AudioManager.Instance.PlaySE(AudioManager.Instance.SE[0]);
        StartCoroutine(Flip(challengecanvas, timecanvas));
    }

    private IEnumerator Flip(GameObject from, GameObject to)
    {
        isFlipping = true;

        float time = 0f;

        // 切り替え先を裏向きでアクティブ
        to.SetActive(true);
        to.transform.localRotation = Quaternion.Euler(0, 180, 0);

        while (time < duration)
        {


            float t = time / duration;

            // A: 0° → 90°
            float fromY = Mathf.Lerp(0f, 90f, t);
            from.transform.localRotation = Quaternion.Euler(0, fromY, 0);

            // B: 180° → 90°
            float toY = Mathf.Lerp(180f, 90f, t);
            to.transform.localRotation = Quaternion.Euler(0, toY, 0);

            time += Time.deltaTime;
            yield return null;
        }

        // 最終位置を保証
        from.transform.localRotation = Quaternion.Euler(0, 90, 0);
        to.transform.localRotation = Quaternion.Euler(0, 90, 0);

        // A を非表示
        from.SetActive(false);

        // B を正面に戻す
        to.transform.localRotation = Quaternion.Euler(0, 0, 0);

        isFlipping = false;
    }
}
