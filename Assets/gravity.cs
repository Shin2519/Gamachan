using UnityEngine;

public class gravity : MonoBehaviour
{
    [SerializeField, Header("èdÇ≥")]
    private float mass;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RectTransform coin_pos = GetComponent<RectTransform>();
        Vector2 Pos = coin_pos.position;
        Pos.y -= 9.8f * mass * Time.deltaTime;
        coin_pos.position = Pos;
    }
}
