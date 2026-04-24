using UnityEngine;
using UnityEngine.EventSystems;

public class String : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public GameObject textBox;

    public void OnPointerEnter(PointerEventData eventData)
    {
        textBox.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        textBox.SetActive(false);
    }
}
