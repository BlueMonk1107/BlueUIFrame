//=======================================================
// 作者：BlueMonk
// 描述：基于UGUI的简易UI框架 
//=======================================================
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BlueUIFrame.Easy
{
    /// <summary>
    /// UI路径管理接口
    /// <para>
    /// 类似与配置文件，需要手动在类的字典UIPathDic里配置路径
    /// </para>
    /// </summary>
    public abstract class AUIPathManager
    {
        protected static Dictionary<string, string> UIPathDic = new Dictionary<string, string>();

        protected abstract void InitPathDic();

        public AUIPathManager()
        {
            InitPathDic();
        }

        /// <summary>
        /// 根据ID获取层级
        /// 需要先在UIPathManager的字典UIPathDic中手动定义路径
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetPath(string id)
        {
            if (UIPathDic.ContainsKey(id))
            {
                return UIPathDic[id];
            }
            else
            {
                Debug.LogError("未在UIPathManager初始化该UI");
                return null;
            }
        }
    }
}
