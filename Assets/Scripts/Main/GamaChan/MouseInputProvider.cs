using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class MouseInputProvider : MonoBehaviour
{
    
    [SerializeField] 
    private UI mouse;
    Texture2D currentCursor;
    [SerializeField]
    private Vector2 HotSpot;
    private Vector2 MovInput;

    private Camera cam;

    private bool f_ispressed;

    public bool IsPressed => f_ispressed;

    void OnMove(InputValue val) => MovInput = val.Get<Vector2>();
    void OnInteract(InputValue val) => f_ispressed = val.isPressed;

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

    void Start()
    {
        currentCursor = mouse.mouse[0];
        Cursor.SetCursor(currentCursor, HotSpot, CursorMode.Auto);
    }

    void Update()
    {
        UpdateCursor();
    }
    void UpdateCursor()
    {
        Texture2D nextCursor = f_ispressed ? mouse.mouse[1] : mouse.mouse[0];

        // �J�[�\�����ς�鎞���� SetCursor ���Ă�
        if (currentCursor != nextCursor)
        {
            Cursor.SetCursor(nextCursor, HotSpot, CursorMode.Auto);
            currentCursor = nextCursor;
        }
    }

    public Vector3 GetWorldPosition()
    {
        if (cam == null) cam = Camera.main;
        Vector3 screen = new Vector3(MovInput.x, MovInput.y, -cam.transform.position.z);
        return cam.ScreenToWorldPoint(screen);
    }
}
