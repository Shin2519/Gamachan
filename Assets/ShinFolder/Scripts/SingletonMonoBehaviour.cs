using UnityEngine;

public abstract class SingletonMonoBehaviour<T> : MonoBehaviour
    where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindFirstObjectByType<T>();

                if (instance == null)
                {
                    Debug.LogError(
                        $"Singleton<{typeof(T).Name}> Ç™ÉVÅ[Éìì‡Ç…ë∂ç›ÇµÇ‹ÇπÇÒ"
                    );
                }
            }
            return instance;
        }
    }

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
}
