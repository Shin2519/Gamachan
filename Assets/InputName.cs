using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;
using System.Collections;
using UnityEngine.Windows;

public class InputName : MonoBehaviour
{
    [Header("��\���e�L�X�g(���͂��Ă�������)")]
    [SerializeField] private TextMeshProUGUI inputText;
    [SerializeField] private TextMeshProUGUI inputText_e;

    [Header("���O���̓X�y�[�X")]
    [SerializeField] private TMP_InputField inputField;//�v���C���[�̖��O�����
    [SerializeField] private TextMeshProUGUI playername;//�v���C���[�̖��O���L��

    [SerializeField] private TextMeshProUGUI namecount;//�����������e�L�X�g

    [SerializeField] private string[] ngword;//NG���[�h���X�g
    [SerializeField] private TextMeshProUGUI ngtext;//NG���[�h�e�L�X�g
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputText.enabled = false;
        inputText_e.enabled = false;
        namecount.enabled = false;
        ngtext.enabled = false;
    }

    void Update()
    {
        if(inputField.text.Length == inputField.characterLimit)
        {
            namecount.enabled = true;
        }

    }

    public void InputText()
    {
        playername.text = inputField.text;//�ύX�\��
    }

    public void OnButtonGame()
    {
        if (inputField.text == "")
        {
            StartCoroutine(stay());
            
        }
        else
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
    public void OnButtonMode()
    {
        //SceneManager.LoadScene("ModeSelectScene");�V�[�����͉�
        Debug.Log("���[�h�I���V�[��");
    }

    //public bool NGWordCheck(string input)
    //{
    //    foreach(var word in ngword)
    //    {
    //        if(input.Contains(word))
    //        {
    //            return true;
    //        }
    //    }
    //    return false;
    //}

    IEnumerator stay()
    {
        inputText.enabled = true;
        inputText_e.enabled = true;
        yield return new WaitForSeconds(2);
        inputText.enabled = false;
        inputText_e.enabled = false;

    }
}
