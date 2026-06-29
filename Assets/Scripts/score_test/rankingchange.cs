using UnityEngine;
using System.Collections;

public class rankingchange: MonoBehaviour
{
    public RectTransform canvasA;
    public RectTransform canvasB;

    public float duration = 0.5f;

    private bool isFlipping = false;

    void Start()
    {
        // 最初は A を表示、B を非表示
        canvasA.gameObject.SetActive(true);
        canvasB.gameObject.SetActive(false);

        canvasA.localRotation = Quaternion.Euler(0, 0, 0);
        canvasB.localRotation = Quaternion.Euler(0, 180, 0); // 裏向きで待機
    }

    public void FlipToCanvasB()
    {
        if (isFlipping) return;
        StartCoroutine(Flip(canvasA, canvasB));
        AudioManager.Instance.PlaySE(AudioManager.Instance.SE[0]);
    }

    public void FlipToCanvasA()
    {
        if (isFlipping) return;
        StartCoroutine(Flip(canvasB, canvasA));
        AudioManager.Instance.PlaySE(AudioManager.Instance.SE[0]);


    }

    private IEnumerator Flip(RectTransform from, RectTransform to)
    {
        isFlipping = true;

        float time = 0f;

        // 切り替え先を裏向きでアクティブ
        to.gameObject.SetActive(true);
        to.localRotation = Quaternion.Euler(0, 180, 0);

        while (time < duration)
        {
            float t = time / duration;

            // A: 0° → 90°
            float fromY = Mathf.Lerp(0f, 90f, t);
            from.localRotation = Quaternion.Euler(0, fromY, 0);

            // B: 180° → 90°
            float toY = Mathf.Lerp(180f, 90f, t);
            to.localRotation = Quaternion.Euler(0, toY, 0);

            time += Time.deltaTime;
            yield return null;
        }

        // 最終位置を保証
        from.localRotation = Quaternion.Euler(0, 90, 0);
        to.localRotation = Quaternion.Euler(0, 90, 0);

        // A を非表示
        from.gameObject.SetActive(false);

        // B を正面に戻す
        to.localRotation = Quaternion.Euler(0, 0, 0);

        isFlipping = false;
    }
}
