//using TMPro;
//using UnityEngine;
//using System.Linq;
//using System.Collections;
//using UnityEngine.InputSystem;
//using System.Text.RegularExpressions;

//public class InputName : MonoBehaviour
//{
//    [SerializeField]
//    private Sound sound;
//    [Header("非表示テキスト(入力してください)")]
//    [SerializeField] private TextMeshProUGUI inputText;
//    [SerializeField] private TextMeshProUGUI inputText_e;

//    [Header("名前入力スペース")]
//    [SerializeField] private TMP_InputField inputField;//プレイヤーの名前を入力

//    [SerializeField] private TextMeshProUGUI namecount;//文字数制限テキスト

//    [SerializeField] private string[] ngword;//NGワードリスト
//    [SerializeField] private TextMeshProUGUI ngtext;//NGワードテキスト
//    [SerializeField] private TextMeshProUGUI ngtext_e;

//    [SerializeField] private Playername pl;//プレイヤーの名前を記憶
//    // Start is called once before the first execution of Update after the MonoBehaviour is created
//    void Start()
//    {
//        inputText.enabled = false;
//        inputText_e.enabled = false;
//        namecount.enabled = false;
//        ngtext.enabled = false;
//        ngtext_e.enabled = false;

//        inputField.onValueChanged.AddListener(delegate { InputText(); });

//    }

//    void Update()
//    {
//        namecount.enabled = inputField.text.Length == inputField.characterLimit;//文字数制限
//        inputField.ActivateInputField();
//        pl.playername = inputField.text.ToString();
//        inputField.text = inputField.text.ToUpper();

//        if(inputField.isFocused)
//        {
//            Input.imeCompositionMode = IMECompositionMode.Off;
//        }

//        if(inputField.text!= Regex.Replace(inputField.text, "[^a-zA-Z]", ""))
//        {
//            return;
//        }
//        InputText();

//        if (Input.GetKey(KeyCode.Return))
//        {
//            if (inputField.text == "")
//            {
//                StartCoroutine(stay());
//            }
//            else if (ngtext.enabled)
//            {

//            }
//            else
//            {
//                if (Mode.Instance.isMode)
//                {
//                    FadeManager.Instance.LoadLevel("New_MainScene", 1.0f,"feature_Gamachan", "feature_UI");//チャレンジモード
                    
//                }
//                else if (!Mode.Instance.isMode)
//                {
//                    FadeManager.Instance.LoadLevel("TimeLimitModeScene", 1.0f,null,null);//タイムリミットモード

//                }
//            }
//            AudioManager.Instance.seSource.PlayOneShot(sound.Click);
//        }
//    }
//    //Inputsystemでの入力(時間があれば)
//    //public void OnNext(InputValue value)
//    //{
//    //    if (inputField.text == "")
//    //    {
//    //        StartCoroutine(stay());

//    //    }
//    //    else if (ngtext.enabled)
//    //    {

//    //    }
//    //    else
//    //    {
//    //        if (Mode.Instance.isMode)
//    //        {
//    //            FadeManager.Instance.LoadLevel("ChallengeModeScene", 1.0f);//チャレンジモード
//    //        }
//    //        else if (!Mode.Instance.isMode)
//    //        {
//    //            FadeManager.Instance.LoadLevel("TimeLimitModeScene", 1.0f);//タイムリミットモード

//    //        }
//    //    }
//    //    audioSource.PlayOneShot(Clip1);
//    //}

//    public void InputText()
//    {
//        bool isNg = false;

//        foreach (string n in ngword)
//        {
//            if (pl.playername.Contains(n))
//            {
//                isNg = true;
//                break;
//            }
//        }

//        ngtext.enabled = isNg;
//        ngtext_e.enabled = isNg;

//        if(isNg)
//        {
//            inputText.enabled = false;
//            inputText_e.enabled = false;
//        }

        
//    }

//    public void OnButtonGame()
//    {
//        if (inputField.text == "")
//        {
//            StartCoroutine(stay());

//        }
//        else if (ngtext.enabled)
//        {

//        }
//        else
//        {
//            if(Mode.Instance.isMode)
//            {
//                FadeManager.Instance.LoadLevel("New_MainScene", 1.0f,"feature_Gamachan","feature_UI");//チャレンジモード
//            }
//            else if(!Mode.Instance.isMode)
//            {
//                FadeManager.Instance.LoadLevel("TimeLimitModeScene", 1.0f,null,null);//タイムリミットモード
//            }
//        }
//        AudioManager.Instance.seSource.PlayOneShot(sound.Click);
//    }
//    public void OnButtonMode()
//    {
//        FadeManager.Instance.LoadLevel("ModeSelectScene", 1.0f, null, null);
//        AudioManager.Instance.seSource.PlayOneShot(sound.Back);
//    }

//    IEnumerator stay()
//    {
//        inputText.enabled = true;
//        inputText_e.enabled = true;
//        yield return new WaitForSeconds(1);
//        inputText.enabled = false;
//        inputText_e.enabled = false;
//    }
//}
