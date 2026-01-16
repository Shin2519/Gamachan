using System.Collections;
using UnityEngine;

public class Delay : MonoBehaviour
{
    private bool isInputEnabled = false;

    void Start()
    {
        StartCoroutine(EnableInputAfterDelay());
    }

    IEnumerator EnableInputAfterDelay()
    {
        yield return new WaitForSecondsRealtime(7f);
        isInputEnabled = true;
    }

    void Update()
    {
        if(!isInputEnabled)
        {
            return;
        }
    }
}
