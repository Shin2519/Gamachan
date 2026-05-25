using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class MouseInputProvider : MonoBehaviour
{
    private Vector2 MovInput;

    private Camera cam;

    public bool IsPressed {get;set;}

    void OnMove(InputValue val) => MovInput = val.Get<Vector2>();
    void OnInteract(InputValue val) => IsPressed = val.isPressed;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        cam = Camera.main;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        cam = Camera.main;
    }

    public Vector3 GetWorldPosition()
    {
        if (cam == null) cam = Camera.main;
        Vector3 screen = new Vector3(MovInput.x, MovInput.y, -cam.transform.position.z);
        return cam.ScreenToWorldPoint(screen);
    }
}
