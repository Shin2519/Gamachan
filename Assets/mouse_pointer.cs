using UnityEngine;

public class mouse_pointer : MonoBehaviour
{
    public Texture2D loupeCursor;

    void OnMouseEnter()
    {
        Cursor.SetCursor(loupeCursor, Vector2.zero, CursorMode.Auto);
    }

    void OnMouseExit()
    {
        //nullにするとデフォルトのテクスチャに戻る
        Cursor.SetCursor(null,Vector2.zero, CursorMode.Auto);
    }
}
