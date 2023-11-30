using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.BaseUtils
{
    public class MonoSingleton<T> : MonoBehaviour  where T : MonoBehaviour
    {
        private static T _instance;
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<T>();
                    if(_instance == null)
                    {
                        Debug.LogError("An Instance of " + typeof(T) + " needed to be in the scene, but there is none.");
                    }
                }
                return _instance;
            }
            private set
            {
                _instance = value;
            }
        }
    }

    public class Singleton<T> where T : class, new()
    {
        private static T _instance;
        private static readonly object _instanceLock = new object();
        public static T Instance
        {
            get
            {
                lock (_instanceLock)
                {
                    if (_instance == null)
                    {
                        _instance = new T();
                    }
                    return _instance;
                }
            }
            private set
            {
                _instance = value;
            }
        }
    }
}