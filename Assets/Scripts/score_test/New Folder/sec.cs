using UnityEngine;
using UnityEngine.UI;

public class OptionIdlePeek : MonoBehaviour
{
    public Image peekCharacter;     // ”`‚­ƒLƒƒƒ‰‚ÌImage
    public float idleLimit = 120f;  // 2•ª = 120•b
    public float peekDuration = 1.5f;

    private float idleTimer = 0f;
    private bool isPeeking = false;

    void Start()
    {
        if (peekCharacter != null)
            peekCharacter.gameObject.SetActive(false);
    }

    void Update()
    {
        if (isPeeking) return;

        idleTimer += Time.deltaTime;

        if (idleTimer >= idleLimit)
        {
            StartCoroutine(Peek());
        }
    }

    public void ResetIdle()
    {
        idleTimer = 0f;
    }

    private System.Collections.IEnumerator Peek()
    {
        isPeeking = true;

        peekCharacter.gameObject.SetActive(true);

        yield return new WaitForSeconds(peekDuration);

        peekCharacter.gameObject.SetActive(false);

        idleTimer = 0f;
        isPeeking = false;
    }
}
