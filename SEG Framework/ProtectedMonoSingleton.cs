using UnityEngine;

public abstract class ProtectedMonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    protected virtual bool bDontDestroyOnLoad => false;

    protected static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(T)) as T;
                if (_instance == null)
                {
                    GameObject obj = new GameObject(typeof(T).Name + " (Singleton)");
                    _instance = obj.AddComponent<T>();

                    // Awake会随AddComponent被调用，此时会根据bDontDestroyOnLoad决定是否DontDestroyOnLoad
                    Debug.Log($"[ProtectedMonoSingleton] Auto-created singleton of {typeof(T).Name}.");
                }
            }
            return _instance;
        }
    }

    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
            if (bDontDestroyOnLoad)
            {
                DontDestroyOnLoad(gameObject);
            }
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void OnDestroy()
    {
        if (_instance == this)
        {
            _instance = null;
        }
    }
}