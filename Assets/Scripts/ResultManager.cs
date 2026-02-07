using UnityEngine;
using UnityEngine.SceneManagement;
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

    [Header("スコア表示用テキスト (10項目)")]
    [SerializeField] private Text[] scoreTexts;

    private int[] scoreValues = new int[11];

    // 最終スコア
    private int finalScore;
    public SendData data; 


    // ランキング送信モード
    public string gameMode = "Challenge";

    public static int modeId;

    [SerializeField] private Playername pl;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        if (ResultManagerBridge.modeId == 0) 
        { 
            gameMode = "Challenge"; 
        } 
        else 
        { 
            gameMode = "TimeLimit"; 
        }
        // 全項目を透明に
        foreach (var item in scoreItems)
        {
            var cg = item.GetComponent<CanvasGroup>();
            if (cg == null) cg = item.gameObject.AddComponent<CanvasGroup>();
            cg.alpha = 0f;
            cg.interactable = false;
            cg.blocksRaycasts = false;
        }

        // ボタン非表示
        foreach (var btn in sceneButtons)
        {
            btn.SetActive(false);
        }

        // スキップ設定
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

    private void SkipAnimation()
    {
        skipRequested = true;
    }

    private IEnumerator PlaySlideIn()
    {
        foreach (var item in scoreItems)
        {
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

            if (!skipRequested)
            {
                yield return new WaitForSeconds(delayBetweenItems);
            }
        }

        // 演出終了後にボタン表示
        foreach (var btn in sceneButtons)
        {
            btn.SetActive(true);
        }
    }

    // スコア受け取り
    public void SetScores(int[] values)
    {
        if (values.Length == scoreValues.Length)
        {
            scoreValues = values;
            UpdateScoreTexts();

            finalScore = values[10]; // 合計スコア
            pl.playerscor = finalScore;
        }
    }

    private void UpdateScoreTexts()
    {
        for (int i = 0; i < scoreTexts.Length; i++)
        {
            scoreTexts[i].text = scoreValues[i].ToString();
        }
    }

    // ランキングへスコア送信
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
