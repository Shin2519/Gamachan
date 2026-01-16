using UnityEngine;

public class TimeLimit : MonoBehaviour
{
    void Awake()
    {
        ResultManagerBridge.modeId = 1; // タイムリミット
    }
}
