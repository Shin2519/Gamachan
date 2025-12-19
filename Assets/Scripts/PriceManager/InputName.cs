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

    [SerializeField] private TextMeshProUGUI namecount;//文字数制限テキスト

    [SerializeField] private string[] ngword;//NGワードリスト
    [SerializeField] private TextMeshProUGUI ngtext;//NGワードテキスト
    [SerializeField] private TextMeshProUGUI ngtext_e;

    Mode mode;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip Clip;
    [SerializeField] private AudioClip Clip1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        inputText.enabled = false;
        inputText_e.enabled = false;
        namecount.enabled = false;
        ngtext.enabled = false;
        ngtext_e.enabled = false;

        inputField.onValueChanged.AddListener(delegate { InputText(); });

        if(inputField != null )
        {
            inputField.Select();
            inputField.ActivateInputField();
        }
    }

    void Update()
    {
        namecount.enabled = inputField.text.Length == inputField.characterLimit;//文字数制限

        
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
        ngtext_e.enabled = isNg;

        if(isNg )
        {
            inputText.enabled = false;
            inputText_e.enabled = false;
        }
    }

    public void OnButtonGame()
    {
        if (inputField.text == "")
        {
            StartCoroutine(stay());

        }
        else if (ngtext.enabled)
        {

        }
        else
        {
            if(Mode.Instance.isMode)
            {
                FadeManager.Instance.LoadLevel("SampleScene", 1.0f);//チャレンジモード
                SceneManager.LoadScene("ChallengeModeScene");//チャレンジモード
            }
            else if(!Mode.Instance.isMode)
            {
                FadeManager.Instance.LoadLevel("TitleScene", 1.0f);//タイムリミットモード
            }
        }
        audioSource.PlayOneShot(Clip1);
    }
    public void OnButtonMode()
    {
        FadeManager.Instance.LoadLevel("ModeSelectScene", 1.0f);
        audioSource.PlayOneShot(Clip);
    }

    IEnumerator stay()
    {
        inputText.enabled = true;
        inputText_e.enabled = true;
        yield return new WaitForSeconds(1);
        inputText.enabled = false;
        inputText_e.enabled = false;

    }
}
