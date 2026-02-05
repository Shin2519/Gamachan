using UnityEngine;

public class MoneyDestroy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Coin"))
        {
            col.gameObject.SetActive(false);
            col.gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }
}
