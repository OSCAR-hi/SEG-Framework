using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SEGFramework
{
    /// <summary>
    /// 挂载式，继承MonoBehaviour的单例模式
    /// e.g., public class GameStateManager : MonoSingleton<GameStateManager>
    /// 
    /// 使用时，继承该类，默认情况下，子类的单例跨场景会被销毁
    /// 如果需要子类的单例跨场景不被销毁，记得在子类中重写bDontDestroyOnLoad属性为true
    /// e.g., protected override bool bDontDestroyOnLoad => true;
    /// 
    /// 如果需要在Awake和OnDestroy中添加额外逻辑，记得在子类中重写Awake和OnDestroy方法
    /// e.g., protected override void Awake()
    /// {
    ///     base.Awake();
    ///     // 额外逻辑
    /// }
    /// 
    /// 如果在Get当前单例时，当前单例并未挂载在场景中，则会在当前场景中自动创建一个单例对象，并调用Awake方法
    /// </summary>
    public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;
        protected virtual bool bDontDestroyOnLoad => false;
        public static T Instance
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
                        Debug.Log($"[MonoSingleton] Auto-created singleton of {typeof(T).Name}.");
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
}