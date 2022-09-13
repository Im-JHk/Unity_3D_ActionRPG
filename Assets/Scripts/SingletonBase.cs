using UnityEngine;

public abstract class SingletonBase<T> where T : SingletonBase<T>, new()
{
    private static T instance = null;

    public static T Instance
    {
        get
        {
            if (instance == null) instance = new();
            return instance;
        }
    }
}
