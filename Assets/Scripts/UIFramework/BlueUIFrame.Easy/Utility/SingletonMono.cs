//=======================================================
// 作者：BlueMonk
// 描述：基于UGUI的简易UI框架
//=======================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlueUIFrame.Easy.Utility
{
    /// <summary>
    /// 基于MonoBehaviour类的单例类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour
    {

        private static T instance;

        public static T Instance
        {
            get
            {
                T t = FindObjectOfType<T>();
                if (instance == null)
                {
                    if (t != null)
                    {
                        instance = t;
                    }
                    else
                    {
                        Debug.LogError("类" + typeof(T).Name + "单例对象为空");
                    }
                }
                return instance;
            }
        }
    }
}
