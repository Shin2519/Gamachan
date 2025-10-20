using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;
using System.Collections;
using UnityEngine.Windows;

public class InputName : MonoBehaviour
{
    [Header("非表示テキスト(入力してください)")]
    [SerializeField] private TextMeshProUGUI inputText;
    [SerializeField] private TextMeshProUGUI inputText_e;

    [Header("名前入力スペース")]
    [SerializeField] private TMP_InputField inputField;//プレイヤーの名前を入力
    [SerializeField] private TextMeshProUGUI playername;//プレイヤーの名前を記憶

    [SerializeField] private TextMeshProUGUI namecount;//文字数制限テキスト

    [SerializeField] private string[] ngword;//NGワードリスト
    [SerializeField] private TextMeshProUGUI ngtext;//NGワードテキスト
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputText.enabled = false;
        inputText_e.enabled = false;
        namecount.enabled = false;
        ngtext.enabled = false;

        inputField.onValueChanged.AddListener(delegate { InputText(); });

        if(inputField != null )
        {
            inputField.Select();
            inputField.ActivateInputField();
        }
    }

    void Update()
    {
        namecount.enabled = inputField.text.Length == inputField.characterLimit;

    }

    public void InputText()
    {
        playername.text = inputField.text;//変更予定

        bool isNg = false;

        foreach (string n in ngword)
        {
            if (playername.text.Contains(n))
            {
                isNg = true;
                break;
            }
        }

        ngtext.enabled = isNg;
    }

    public void OnButtonGame()
    {
        if (inputField.text == "")
        {
            StartCoroutine(stay());
            
        }
        else if(ngtext.enabled)
        {

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

    IEnumerator stay()
    {
        inputText.enabled = true;
        inputText_e.enabled = true;
        yield return new WaitForSeconds(2);
        inputText.enabled = false;
        inputText_e.enabled = false;

    }
}
