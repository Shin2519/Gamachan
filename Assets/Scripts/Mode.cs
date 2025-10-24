using UnityEngine;

public class Mode : MonoBehaviour
{
    public static Mode Instance { get; private set; }

    public bool isMode;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
