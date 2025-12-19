using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class ResultManager : MonoBehaviour
{
    [Header("SE設定")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clickSE;

    [Header("リザルト演出設定")]
    [SerializeField] private RectTransform[] scoreItems; // スコア項目をInspectorでセット
    [SerializeField] private float slideDuration = 0.5f; // 1項目のスライド時間
    [SerializeField] private float delayBetweenItems = 0.2f; // 項目間の待機時間
    [SerializeField] private float startOffsetY = -200f; // 下から出てくる距離

    [Header("演出スキップ用")]
    [SerializeField] private Image skipImage; // 演出スキップ用のイメージをInspectorでセット
    private bool skipRequested = false;

    [Header("シーン遷移ボタン")]
    [SerializeField] private GameObject[] sceneButtons; // Ranking/Title/ModeSelectボタンをInspectorでセット

    [Header("スコア表示用テキスト (10項目)")]
    [SerializeField] private Text[] scoreTexts;
    // Inspectorで10個のTextを順番にセットしておく
    // 順番: Perfect, Great, Good, Bad, おつりボーナス, ゴールデンボーナス, コンボボーナス, スピードボーナス, おつり合計, 最終スコア

    private int[] scoreValues = new int[10]; // 受け取ったスコア値を保持

    private void Start()
    {
        // 全項目を最初に透明にしておく
        foreach (var item in scoreItems)
        {
            var cg = item.GetComponent<CanvasGroup>();
            if (cg == null) cg = item.gameObject.AddComponent<CanvasGroup>();
            cg.alpha = 0f;
            cg.interactable = false;
            cg.blocksRaycasts = false;
        }

        // ボタンは演出が終わるまで非表示
        foreach (var btn in sceneButtons)
        {
            btn.SetActive(false);
        }

        // スキップ用イメージにクリックイベントを追加
        if (skipImage != null)
        {
            skipImage.GetComponent<Button>().onClick.AddListener(SkipAnimation);
        }

        // 演出開始
        if (scoreItems != null && scoreItems.Length > 0)
        {
            StartCoroutine(PlaySlideIn());
        }
    }

    private void PlayClickSE()
    {
        if (clickSE != null && audioSource != null)
        {
            audioSource.PlayOneShot(clickSE);
        }
    }

    // 演出スキップ処理
    private void SkipAnimation()
    {
        skipRequested = true;
    }

    // スコア項目を順番にスライド＋フェード表示する演出
    private IEnumerator PlaySlideIn()
    {
        foreach (var item in scoreItems)
        {
            var cg = item.GetComponent<CanvasGroup>();

            // 初期位置を下にずらす
            Vector2 startPos = item.anchoredPosition + new Vector2(0, startOffsetY);
            Vector2 endPos = item.anchoredPosition;
            item.anchoredPosition = startPos;

            float elapsed = 0f;
            while (elapsed < slideDuration && !skipRequested)
            {
                elapsed += Time.deltaTime;
                float t = Mathf.Clamp01(elapsed / slideDuration);

                // スライド
                item.anchoredPosition = Vector2.Lerp(startPos, endPos, t);
                // フェードイン
                cg.alpha = t;

                yield return null;
            }

            // スキップされた場合は即座に最終状態へ
            item.anchoredPosition = endPos;
            cg.alpha = 1f;
            cg.interactable = true;
            cg.blocksRaycasts = true;

            if (!skipRequested)
            {
                yield return new WaitForSeconds(delayBetweenItems);
            }
        }

        // 演出終了後にスコア値を表示
        UpdateScoreTexts();

        // ボタンを表示
        foreach (var btn in sceneButtons)
        {
            btn.SetActive(true);
        }
    }

    // 外部からスコア値を受け取る
    public void SetScores(int[] values)
    {
        if (values.Length == scoreValues.Length)
        {
            scoreValues = values;
        }
    }

    // スコア値をUIに反映
    private void UpdateScoreTexts()
    {
        for (int i = 0; i < scoreTexts.Length; i++)
        {
            scoreTexts[i].text = scoreValues[i].ToString();
        }
    }

    // シーン遷移系
    public void GoToRankingScene()
    {
        PlayClickSE();
        FadeManager.Instance.LoadLevel("RankingScene",1.0f);
    }

    public void GoToTitleScene()
    {
        PlayClickSE();
        FadeManager.Instance.LoadLevel("TitleScene", 1.0f);
    }

    public void GoToModeSelectScene()
    {
        PlayClickSE();
        FadeManager.Instance.LoadLevel("ModeSelectScene", 1.0f);
    }
}
