using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResultManager : MonoBehaviour
{
    public static ResultManager Instance;

    [Header("リザルト演出設定")]
    [SerializeField] private RectTransform[] scoreItems;
    [SerializeField] private float slideDuration = 0.5f;
    [SerializeField] private float delayBetweenItems = 0.2f;
    [SerializeField] private float startOffsetY = -200f;

    [Header("演出スキップ用")]
    [SerializeField] private Image skipImage;
    private bool skipRequested = false;

    [Header("シーン遷移ボタン")]
    [SerializeField] private GameObject[] sceneButtons;

    [Header("スコア表示用テキスト (11項目)")]
    [SerializeField] private Text[] scoreTexts;

    // 0〜9: 各項目 / 10: 合計スコア（最終値）
    private int[] scoreValues = new int[11];

    private int currentTotalScore = 0;
    private int targetTotalScore = 0;

    public SendData data;
    public string gameMode = "Challenge";
    public static int modeId;

    [SerializeField] private Playername pl;

    private void Awake()
    {
        Instance = this;
    }

    public void ActiveAndSlide()
    {
        gameMode = (ResultManagerBridge.modeId == 0) ? "Challenge" : "TimeLimit";

        foreach (var item in scoreItems)
        {
            var cg = item.GetComponent<CanvasGroup>();
            if (cg == null) cg = item.gameObject.AddComponent<CanvasGroup>();
            cg.alpha = 0f;
            cg.interactable = false;
            cg.blocksRaycasts = false;
        }

        foreach (var btn in sceneButtons)
        {
            btn.SetActive(false);
        }

        skipRequested = false;
        if (skipImage != null)
        {
            var btn = skipImage.GetComponent<Button>();
            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(SkipAnimation);
        }

        StartCoroutine(PlaySlideIn());
    }

    private void SkipAnimation()
    {
        skipRequested = true;
    }

    private IEnumerator AddToTotalScore(int addValue)
    {
        int start = currentTotalScore;
        int end = currentTotalScore + addValue;
        float duration = 0.25f;
        float elapsed = 0f;

        while (elapsed < duration && !skipRequested)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);
            int current = (int)Mathf.Lerp(start, end, t);
            scoreTexts[10].text = current.ToString();
            yield return null;
        }

        currentTotalScore = end;
        scoreTexts[10].text = currentTotalScore.ToString();
    }

    private IEnumerator PlaySlideIn()
    {
        // トータルは最初 0 表示
        currentTotalScore = 0;
        scoreTexts[10].text = "0";

        for (int i = 0; i < scoreItems.Length; i++)
        {
            var item = scoreItems[i];
            var cg = item.GetComponent<CanvasGroup>();

            Vector2 startPos = item.anchoredPosition + new Vector2(0, startOffsetY);
            Vector2 endPos = item.anchoredPosition;
            item.anchoredPosition = startPos;

            float elapsed = 0f;
            while (elapsed < slideDuration && !skipRequested)
            {
                elapsed += Time.deltaTime;
                float t = Mathf.Clamp01(elapsed / slideDuration);

                item.anchoredPosition = Vector2.Lerp(startPos, endPos, t);
                cg.alpha = t;

                yield return null;
            }

            item.anchoredPosition = endPos;
            cg.alpha = 1f;
            cg.interactable = true;
            cg.blocksRaycasts = true;

            // トータル加算（最後の index 10 は除外）
            if (i < scoreValues.Length - 1)
            {
                int addValue = scoreValues[i];
                StartCoroutine(AddToTotalScore(addValue));
            }

            if (!skipRequested)
            {
                yield return new WaitForSeconds(delayBetweenItems);
            }
            else
            {
                break;
            }
        }

        // スキップされた場合は一気に最終値へ
        if (skipRequested)
        {
            currentTotalScore = targetTotalScore;
            scoreTexts[10].text = targetTotalScore.ToString();

            for (int i = 0; i < scoreItems.Length; i++)
            {
                var item = scoreItems[i];
                var cg = item.GetComponent<CanvasGroup>();
                cg.alpha = 1f;
                cg.interactable = true;
                cg.blocksRaycasts = true;
            }
        }

        foreach (var btn in sceneButtons)
        {
            btn.SetActive(true);
        }
    }

    public void SetScores(int[] values)
    {
        if (values.Length == scoreValues.Length)
        {
            scoreValues = values;

            // 0〜9 の項目をそのまま表示
            for (int i = 0; i < scoreTexts.Length - 1; i++)
            {
                scoreTexts[i].text = scoreValues[i].ToString();
            }

            // トータルは演出で加算するので 0 にしておく
            targetTotalScore = scoreValues[10];
            currentTotalScore = 0;
            scoreTexts[10].text = "0";

            // ランキング送信用
            pl.playerscor = targetTotalScore;
        }
    }

    public void ReceiveGameData(SendData sendData)
    {
        int[] scoreArray = ScoreCalculator.Instance.ScoreData(sendData);
        SetScores(scoreArray);
        ActiveAndSlide();
    }

    public void GoToRankingScene()
    {
        FadeManager.Instance.LoadLevel("RankingScene", 1.0f);
    }

    public void GoToTitleScene()
    {
        FadeManager.Instance.LoadLevel("TitleScene", 1.0f);
    }

    public void GoToModeSelectScene()
    {
        FadeManager.Instance.LoadLevel("ModeSelectScene", 1.0f);
    }
}
