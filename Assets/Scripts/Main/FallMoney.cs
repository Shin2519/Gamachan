using UnityEngine;

public class FallMoney : MonoBehaviour
{
    Rigidbody2D rd2D;

    public int MyMoney;

    [SerializeField, Header("èâë¨ìx")]
    float v0_;

    void Awake()
    {
        rd2D = GetComponent<Rigidbody2D>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rd2D.linearVelocity = Vector3.down * v0_;
    }
}
