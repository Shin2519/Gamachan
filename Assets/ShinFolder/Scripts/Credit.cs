using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] Canvas Titile;
    [SerializeField] Canvas Option;

    [SerializeField] Button GoCredit;
    [SerializeField] Button Page1;
    [SerializeField] Button Page2;

    [SerializeField] GameObject Credit;
    [SerializeField] GameObject Member;

    void Start()
    {
        gameObject.SetActive(false);
        Member.SetActive(false);
    }

    public void Change_CT()
    {
        gameObject.SetActive(true);
        Titile.enabled = false;
        Option.enabled = false;
    }

    public void Change_TL()
    {
        gameObject.SetActive(false);
        Titile.enabled = true;
        Option.enabled = true;
    }

    public async void Change_PG2()
    {
        Member.SetActive(true) ;
        //await Delay();
        Credit.SetActive(false);
    }

    public async void Change_PG1()
    {
        Credit.SetActive(true);
        //await Delay();
        Member.SetActive(false);
    }

    private async Task Delay()
    {
        await Task.Delay(10);
    }
}
