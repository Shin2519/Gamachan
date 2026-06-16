using UnityEngine;
[CreateAssetMenu(fileName = "Texture", menuName = "Scriptable Objects/MouseCursorTexture")]
public class MouseCursorTexture : ScriptableObject
{
    [SerializeField,Header("マウスカーソルに使うテクスチャ")]
    private Texture2D[] mouse;

    public Texture2D GetMouseCursorTexture(int num) => mouse[num];
}
