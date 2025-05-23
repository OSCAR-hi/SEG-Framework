using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System;

namespace SEG.Framework.Utility
{
    /// <summary>
    /// 单例
    /// </summary>
    public class Singleton<T>
    {
        private static readonly T instance = Activator.CreateInstance<T>();

        public static T Instance { get { return instance; } }
    }
}
