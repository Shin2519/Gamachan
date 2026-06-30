using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ResultManagement : MonoBehaviour
{
    public static ResultManagement Instance;

    [Header("リザルト演出設定")]
    [SerializeField] private RectTransform[] scoreItems;

    [SerializeField] private float slideDuration = 0.5f;

    [SerializeField] private float delayBetweenItems = 0.2f;

    [SerializeField] private float startOffsetY = -200f;

    [SerializeField] private float countDuration = 0.25f;

    [Header("シーン遷移ボタン")]
    [SerializeField] private GameObject[] sceneButtons;

    [Header("スコア表示用テキスト (11項目)")]
    [SerializeField] private Text[] scoreTexts;

    private const int TotalIndex = 10;

    // 0〜9: 各項目 / 10: 合計スコア（最終値）
    private int[] scoreValues = new int[11];

    private int currentTotalScore = 0;
    
    Sequence slidesequence;

    bool sequenceskip  = true;

    public string gameMode = "Challenge";

    public static int modeId;

    public bool p_skip => sequenceskip;
    private void Awake()
    {
        Instance = this;

        sequenceskip = true;
    }
    public void ActiveAndSlide()
    {
        gameMode = (ResultManagerBridge.modeId == 0) ? "Challenge" : "TimeLimit";

        Initializeitems();
        
        SetSceneButtons(true);

        slidesequence = BuildSequence();
    }

    void Initializeitems()
    {
        foreach (var item in scoreItems)
        {
            var cg = item.GetComponent<CanvasGroup>();
            if (cg == null) cg = item.gameObject.AddComponent<CanvasGroup>();
            cg.alpha = 0f;
            cg.interactable = false;
        }
    }

    void SetSceneButtons(bool active)
    {
        foreach (var btn in sceneButtons) btn.SetActive(active);
    }
    Sequence BuildSequence()
    {
        currentTotalScore = 0;
        var seq = DOTween.Sequence();

        for (int i = 0; i < scoreItems.Length; i++)
        seq.Append(BuildItemTween(i)).AppendInterval(delayBetweenItems);

        return seq.AppendCallback(OnAnimationFinished);
    }

    Sequence BuildItemTween(int index)
    {
        var item = scoreItems[index];
    var cg = item.GetComponent<CanvasGroup>();

    Vector2 endPos = item.anchoredPosition;
    item.anchoredPosition = endPos + new Vector2(0, startOffsetY);

    return DOTween.Sequence()
        .Append(item.DOAnchorPos(endPos, slideDuration))
        .Join(cg.DOFade(1f, slideDuration))
        .AppendCallback(() =>
        {
            cg.interactable = cg.blocksRaycasts = true;
            if (index < TotalIndex) CountUpScore(scoreValues[index]);
        });
    }
    void OnAnimationFinished()
    {
        currentTotalScore = scoreValues[TotalIndex];
        scoreTexts[TotalIndex].text = currentTotalScore.ToString();
        SetSceneButtons(true);
    }

    void CountUpScore(int addValue)
    {
        int target = currentTotalScore + addValue;
        DOTween.To(
            () => currentTotalScore,
            x => { currentTotalScore = x; scoreTexts[TotalIndex].text = x.ToString(); },
            target,
            countDuration
        );
    }

    public void SequenceSkip()
    {
        slidesequence?.Complete();

        sequenceskip = false;
    }
}
