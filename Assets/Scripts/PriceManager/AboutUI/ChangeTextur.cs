using UnityEngine;

public class ChangeTextur : MonoBehaviour
{
    [SerializeField]
    private UI mouse;

    Texture2D currentCursor;
    [SerializeField]
    private Vector2 HotSpot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void UpdateCursor()
    {
        //Texture2D nextCursor = IsInter ? mouse.mouse[1] : mouse.mouse[0];

        // ƒJ[ƒ\ƒ‹‚ª•Ï‚í‚é‚¾‚¯ SetCursor ‚ğŒÄ‚Ô
        //if (currentCursor != nextCursor)
        //{
        //    Cursor.SetCursor(nextCursor, HotSpot, CursorMode.Auto);
        //    currentCursor = nextCursor;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
