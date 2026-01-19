using UnityEngine;
using UnityEngine.UI;

public class FinalTotal : MonoBehaviour
{
    ScoreCalculator scoreCalculator;

    SendTotalData sendTotalData;

    [SerializeField]
    Text[] Result_Text;
    void Awake()
    {
        scoreCalculator = GetComponent<ScoreCalculator>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreCalculator.CalculateChallenge(0,0,0,0,0,0,sendTotalData.Combo_count,0,0,0,0,0);

        Result_Text[0].text = scoreCalculator.CalculateChallenge(0, 0, 0, 0, 0, 0, sendTotalData.Combo_count, 0, 0, 0, 0, 0).perfectScore.ToString();
        Result_Text[1].text = scoreCalculator.CalculateChallenge(0, 0, 0, 0, 0, 0, sendTotalData.Combo_count, 0, 0, 0, 0, 0).greatScore.ToString();
        Result_Text[2].text = scoreCalculator.CalculateChallenge(0, 0, 0, 0, 0, 0, sendTotalData.Combo_count, 0, 0, 0, 0, 0).goodScore.ToString();
        Result_Text[3].text = scoreCalculator.CalculateChallenge(0, 0, 0, 0, 0, 0, sendTotalData.Combo_count, 0, 0, 0, 0, 0).badScore.ToString();
        Result_Text[4].text = scoreCalculator.CalculateChallenge(0, 0, 0, 0, 0, 0, sendTotalData.Combo_count, 0, 0, 0, 0, 0).diffScore.ToString();
        Result_Text[5].text = scoreCalculator.CalculateChallenge(0, 0, 0, 0, 0, 0, sendTotalData.Combo_count, 0, 0, 0, 0, 0).perfectScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
