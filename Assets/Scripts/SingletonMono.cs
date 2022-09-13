using UnityEngine;

public abstract class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance = null;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (T)FindObjectOfType(typeof(T));
                if (instance == null)
                {
                    var obj = new GameObject(typeof(T).ToString());
                    instance = obj.AddComponent<T>();
                }
            }
            return instance;
        }
    }
}
