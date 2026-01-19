using UnityEngine;
using UnityEngine.UI;

public class CountDoune : MonoBehaviour
{
    [SerializeField] private GameObject selectgoods;
    [SerializeField] private Image three;
    [SerializeField] private Image two;
    [SerializeField] private Image one;
    [SerializeField] private Image start;
    public float timer;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        selectgoods.SetActive(false);
        three.enabled = false;
        two.enabled = false;
        one.enabled = false;
        start.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 4 && timer >= 3)
        {
            three.enabled=true;
        }
        else if(timer <= 3 && timer >= 2)
        {
            three.enabled = false;
            two.enabled=true;
        }
        else if(timer <= 2 && timer >= 1)
        {
            two.enabled=false;
            one.enabled=true;
        }
        else if(timer <= 1 && timer >= 0)
        {
            one.enabled=false;
            start.enabled=true;
        }


        if(timer<=0)
        {
            start.enabled=false;
            selectgoods.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        timer -= Time.deltaTime;
    }
}
