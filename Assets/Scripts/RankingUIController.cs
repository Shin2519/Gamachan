using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // ← 追加

public class RankingUIController : MonoBehaviour
{
    [Header("チャレンジモード用UI")]
    public Text[] challengeRankTexts;

    [Header("タイムリミットモード用UI")]
    public Text[] timeLimitRankTexts;

    [SerializeField]private Playername pl;

    private void Start()
    {
        //RankingManager.Instance.ResetRanking();
        RankingManager.Instance.LoadRanking();
        UpdateRankingUI();
    }

    public void UpdateRankingUI()
    {
        for (int i = 0; i < challengeRankTexts.Length; i++)
        {
            if (i < RankingManager.Instance.challengeRanking.Count)
            {
                var entry = RankingManager.Instance.challengeRanking[i];
                challengeRankTexts[i].text = $"{i + 1}位: {entry.playerName} - {entry.score}";
            }
            else
            {
                challengeRankTexts[i].text = $"{i + 1}位: ---";
            }
        }

        for (int i = 0; i < timeLimitRankTexts.Length; i++)
        {
            if (i < RankingManager.Instance.timeLimitRanking.Count)
            {
                var entry = RankingManager.Instance.timeLimitRanking[i];
                timeLimitRankTexts[i].text = $"{i + 1}位: {entry.playerName} - {entry.score}";
            }
            else
            {
                timeLimitRankTexts[i].text = $"{i + 1}位: ---";
            }
        }
    }

    // ★ 追加：タイトルシーンへ戻るボタン用
    public void GoToTitleScene()
    {
        SceneManager.LoadScene("TitleScene");
    }

}
