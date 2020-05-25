using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T _Instance;

    public static bool IsInitialized
    {
        get
        {
            return _Instance != null;
        }
    }

    protected virtual void Awake()
    {
        _Instance = (T)this;
    }

    protected virtual void OnDestroy()
    {
        _Instance = null;
    }

    public static T Instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = FindObjectOfType<T>();
            }
            return _Instance;
        }
    }
}