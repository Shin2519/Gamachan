using UnityEngine;
using UnityEngine.UI;

public class FinalTotal : MonoBehaviour
{
    ScoreCalculator scoreCalculator;
    [SerializeField]
    SendData sendTotalData;

    [SerializeField]
    Text[] Result_Text;
    void Awake()
    {
        scoreCalculator = GetComponent<ScoreCalculator>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreCalculator.CalculateChallenge(sendTotalData.Perfect_count,
                                                                     sendTotalData.Great_count,
                                                                     sendTotalData.Good_count, 
                                                                     sendTotalData.Bad_count,
                                                                     sendTotalData.JustSumAmount_Bonus,
                                                                     0,
                                                                     sendTotalData.Combo_count,
                                                                     0,
                                                                     0,
                                                                     0,
                                                                     0,
                                                                     sendTotalData.TotalSumAmount);

        Result_Text[0].text = scoreCalculator.CalculateChallenge(sendTotalData.Perfect_count, sendTotalData.Great_count, sendTotalData.Good_count, sendTotalData.Bad_count, sendTotalData.JustSumAmount_Bonus, 0, sendTotalData.Combo_count, 0, 0, 0, 0, sendTotalData.TotalSumAmount).perfectScore.ToString();
        Result_Text[1].text = scoreCalculator.CalculateChallenge(sendTotalData.Perfect_count, sendTotalData.Great_count, sendTotalData.Good_count, sendTotalData.Bad_count, sendTotalData.JustSumAmount_Bonus, 0, sendTotalData.Combo_count, 0, 0, 0, 0, sendTotalData.TotalSumAmount).greatScore.ToString();
        Result_Text[2].text = scoreCalculator.CalculateChallenge(sendTotalData.Perfect_count, sendTotalData.Great_count, sendTotalData.Good_count, sendTotalData.Bad_count, sendTotalData.JustSumAmount_Bonus, 0, sendTotalData.Combo_count, 0, 0, 0, 0, sendTotalData.TotalSumAmount).goodScore.ToString();
        Result_Text[3].text = scoreCalculator.CalculateChallenge(sendTotalData.Perfect_count, sendTotalData.Great_count, sendTotalData.Good_count, sendTotalData.Bad_count, sendTotalData.JustSumAmount_Bonus, 0, sendTotalData.Combo_count, 0, 0, 0, 0, sendTotalData.TotalSumAmount).badScore.ToString();
        Result_Text[4].text = scoreCalculator.CalculateChallenge(sendTotalData.Perfect_count, sendTotalData.Great_count, sendTotalData.Good_count, sendTotalData.Bad_count, sendTotalData.JustSumAmount_Bonus, 0, sendTotalData.Combo_count, 0, 0, 0, 0, sendTotalData.TotalSumAmount).diffScore.ToString();
        Result_Text[5].text = scoreCalculator.CalculateChallenge(sendTotalData.Perfect_count, sendTotalData.Great_count, sendTotalData.Good_count, sendTotalData.Bad_count, sendTotalData.JustSumAmount_Bonus, 0, sendTotalData.Combo_count, 0, 0, 0, 0, sendTotalData.TotalSumAmount).goldenBonus.ToString();
        Result_Text[8].text = scoreCalculator.CalculateChallenge(sendTotalData.Perfect_count, sendTotalData.Great_count, sendTotalData.Good_count, sendTotalData.Bad_count, sendTotalData.JustSumAmount_Bonus, 0, sendTotalData.Combo_count, 0, 0, 0, 0, sendTotalData.TotalSumAmount).totalScore.ToString();
        Result_Text[9].text = scoreCalculator.CalculateChallenge(sendTotalData.Perfect_count, sendTotalData.Great_count, sendTotalData.Good_count, sendTotalData.Bad_count, sendTotalData.JustSumAmount_Bonus, 0, sendTotalData.Combo_count, 0, 0, 0, 0, sendTotalData.TotalSumAmount).totalScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
