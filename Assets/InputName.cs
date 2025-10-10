using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputName : MonoBehaviour
{
    [Header("��\���e�L�X�g(���͂��Ă�������)")]
    [SerializeField] private TextMeshProUGUI inputText;
    [SerializeField] private TextMeshProUGUI inputText_e;

    [Header("���O���̓X�y�[�X")]
    [SerializeField] private TMP_InputField inputField;//�v���C���[�̖��O�����
    [SerializeField] private TextMeshProUGUI playername;//�v���C���[�̖��O���L��
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
        //SceneManager.LoadScene("ModeSelectScene");�V�[�����͉�
        Debug.Log("���[�h�I���V�[��");
    }
}
