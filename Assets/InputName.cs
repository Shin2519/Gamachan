using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputName : MonoBehaviour
{
    [Header("非表示テキスト(入力してください)")]
    [SerializeField] private TextMeshProUGUI inputText;
    [SerializeField] private TextMeshProUGUI inputText_e;

    [Header("名前入力スペース")]
    [SerializeField] private TMP_InputField inputField;//プレイヤーの名前を入力
    [SerializeField] private TextMeshProUGUI playername;//プレイヤーの名前を記憶
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputText.enabled = false;
        inputText_e.enabled = false;
       
    }

    public void InputText()
    {
        playername.text = inputField.text;
    }

    public void OnButtonGame()
    {
       
        if(inputField.text == "")
        {
            inputText.enabled = true;
            inputText_e.enabled = true;
        }
        else
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
    public void OnButtonMode()
    {
        //SceneManager.LoadScene("ModeSelectScene");シーン名は仮
        Debug.Log("モード選択シーン");
    }
}
