using TMPro;
using UnityEngine;

public class RejisterAmount : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI targetAmount;//–Ú•W‹àŠz
    [SerializeField] private TextMeshProUGUI inputAmount;//“ü—Í‹àŠz
    [SerializeField] private TextMeshProUGUI sumAmount;//‡Œv‹àŠz

    public void TargetAmount(int amount)
    {
        targetAmount.text = amount.ToString();
    }

    public void InputAmount(int amount)
    {
        inputAmount.text = amount.ToString();
    }

    public void SumAmount(int amount)
    {
        sumAmount.text = amount.ToString();
    }

}
