using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T instance;
    protected virtual void CreateInstance()
    {
        if (instance != null && instance != this)
        {
            Debug.LogError("Instance already exists");
            Destroy(this.gameObject);
            return;
        }
    }
}
