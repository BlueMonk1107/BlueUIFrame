using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using BlueUIFrame.Easy.Utility;

namespace BlueUIFrame.Easy
{
    public class MsgManager : SingletonMono<MsgManager>
    {
        private Dictionary<string, Action<IPara>> actionDic;

        public void Init()
        {
            actionDic = new Dictionary<string, Action<IPara>>();
        }

        public void AddListener(string key, Action<IPara> action)
        {
            if (!actionDic.ContainsKey(key))
            {
                actionDic[key] = action;
            }
            else
            {
                Debug.LogError("消息系统键值重复，重复项为:" + key);
            }

        }

        public void RemoveListener(string key)
        {
            if (actionDic.ContainsKey(key))
            {
                actionDic.Remove(key);
            }
        }

        public void RemoveListener(Action<IPara> action)
        {
            if (actionDic.ContainsValue(action))
            {
                foreach (var pair in actionDic)
                {
                    if (pair.Value == action)
                    {
                        actionDic.Remove(pair.Key);
                        break;
                    }
                }
            }
        }

        public void SendMessage(string key, IPara para)
        {
            if (actionDic.ContainsKey(key))
            {
                Action<IPara> action = actionDic[key];
                if (action != null)
                {
                    action(para);
                }
                else
                {
                    Debug.LogError("存在键值" + key + "但委托为空");
                }
            }
            else
            {
                Debug.LogError("消息系统不含键值:" + key);
            }
        }
    }
}