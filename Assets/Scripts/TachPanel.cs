using TMPro;
using UnityEngine;

public class TachPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI sumamounttext;//çáåvã‡äzÉeÉLÉXÉg(â~)
    [SerializeField]private TextMeshProUGUI sumamountyen;//çáåvã‡äzÉeÉLÉXÉg
    [SerializeField] private TextMeshProUGUI amounttext;//è§ïiÇÃã‡äzÉeÉLÉXÉg
    [SerializeField] private TextMeshProUGUI inputamounttext;//ìäì¸ã‡äz(âº)ÉeÉLÉXÉg

    private int sumamount = 0;
    private int amount = 100;
    private int inputamount = 150;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sumamounttext.text = sumamount.ToString() + "â~";
        amounttext.text = amount.ToString() + "â~";
        inputamounttext.text = inputamount.ToString() + "â~";

        sumamounttext.enabled = false;
        sumamountyen.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnButton()
    {
        sumamount = amount - inputamount;
        sumamounttext.enabled = true;
        sumamountyen.enabled = true;

        if (sumamount >0)
        {
            sumamountyen.text = "Ç®íﬁÇË";
            sumamounttext.text =  sumamount.ToString() + "â~";
            sumamounttext.color = Color.blue;
        }
        else
        {
            sumamountyen.text = "éxï•écäz";
            sumamounttext.text = sumamount.ToString() + "â~";
            sumamounttext.color = Color.red;
        }

    }
}
