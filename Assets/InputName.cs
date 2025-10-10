using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;
using System.Collections;

public class InputName : MonoBehaviour
{
    [Header("非表示テキスト(入力してください)")]
    [SerializeField] private TextMeshProUGUI inputText;
    [SerializeField] private TextMeshProUGUI inputText_e;

    [Header("名前入力スペース")]
    [SerializeField] private TMP_InputField inputField;//プレイヤーの名前を入力
    [SerializeField] private TextMeshProUGUI playername;//プレイヤーの名前を記憶

    [SerializeField] private TextMeshProUGUI namecount;

    [SerializeField] private string[] ngword;//NGワードリスト
    [SerializeField] private TextMeshProUGUI ngtext;
    private bool isNgword;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputText.enabled = false;
        inputText_e.enabled = false;
        isNgword = false;
        namecount.enabled = false;
        ngtext.enabled = false;
    }

    private void Update()
    {
        if(inputField.text.Length == inputField.characterLimit)
        {
            namecount.enabled = true;
        }

        //if (ngword.Length == playername.text.Length)
        //{
        //    Debug.Log(isNgword);
        //    isNgword = true;
        //}
        //else
        //{
        //    isNgword = false;
        //}
    }

    public void InputText()
    {
        playername.text = inputField.text;
    }

    public void OnButtonGame()
    {
        if (inputField.text == "")
        {
            StartCoroutine(stay());
            
        }
        //else if(isNgword==true)
        //{
        //    ngtext.enabled = true;
        //}
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
