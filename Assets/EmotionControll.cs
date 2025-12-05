using UnityEngine;

public class EmotionControll : MonoBehaviour
{
    [SerializeField]
    Sprite NomalEmotion;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Sprite GamaEmotion = transform.gameObject.GetComponent<Sprite>();
        GamaEmotion = NomalEmotion;
    }
}
