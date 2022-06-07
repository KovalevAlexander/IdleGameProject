using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance != null)
                return instance;
            else
            {
                return instance = GameObject.FindObjectOfType<T>();
            }
        }
        set
        {
            instance = value;
        }
    }

    protected void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this as T;
        }
    }
}
