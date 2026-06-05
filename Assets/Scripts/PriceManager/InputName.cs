using TMPro;
using UnityEngine;
using System.Linq;
using System.Collections;
using UnityEngine.InputSystem;
using System.Text.RegularExpressions;

public class InputName : MonoBehaviour
{
    [SerializeField]
    private Sound sound;
    [Header("非表示テキスト(入力してください)")]
    [SerializeField] private TextMeshProUGUI inputText;
    [SerializeField] private TextMeshProUGUI inputText_e;

    [Header("名前入力スペース")]
    [SerializeField] public TMP_InputField inputField;//プレイヤーの名前を入力

    [SerializeField] private TextMeshProUGUI namecount;//文字数制限テキスト

    [SerializeField] private string[] ngword;//NGワードリスト
    [SerializeField] private TextMeshProUGUI ngtext;//NGワードテキスト
    [SerializeField] private TextMeshProUGUI ngtext_e;

    [SerializeField] private PlayerInput playerInput;

    public static InputName instance;

    private void Awake()
    {
        playerInput=GetComponent<PlayerInput>();
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputText.enabled = false;
        inputText_e.enabled = false;
        namecount.enabled = false;
        ngtext.enabled = false;
        ngtext_e.enabled = false;

        if (inputField.isFocused)
        {
            Input.imeCompositionMode = IMECompositionMode.Off;
        }
    }

    void Update()
    {
        namecount.enabled = inputField.text.Length == inputField.characterLimit;//文字数制限
        inputField.ActivateInputField();
        inputField.text = inputField.text.ToUpper();

        if (playerInput.actions["InputName"].WasPressedThisFrame())
        {
            if (inputField.text == "")
            {
                StartCoroutine(stay());

            }
            else if (ngtext.enabled)
            {
                InputText();
            }
            else
            {
                this.gameObject.SetActive(false);
            }

                AudioManager.Instance.seSource.PlayOneShot(sound.Click);
        }

        if(inputField.text!= Regex.Replace(inputField.text, "[^a-zA-Z]", ""))
        {
            return;
        }
        InputText();

        
    }

    public void InputText()
    {
        bool isNg = false;

        foreach (string n in ngword)
        {
            if (inputField.text.Contains(n))
            {
                isNg = true;
                break;
            }
        }

        ngtext.enabled = isNg;
        ngtext_e.enabled = isNg;

        if(isNg)
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
            InputText();
        }
        else
        {
            this.gameObject.SetActive(false);
        }

        AudioManager.Instance.seSource.PlayOneShot(sound.Click);
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
