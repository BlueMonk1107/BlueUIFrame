using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace BlueUIFrame.Easy.Utility
{
    public class UITool
    {

        public static void AddBtnListener(Transform parent, UnityAction action, string buttonName = "")
        {
            if (parent == null || action == null)
            {
                Debug.LogError("The parameter 'parent' or 'action' of the UITool.AddBtnListener method cannot be null");
                return;
            }
            if (!string.IsNullOrEmpty(buttonName))
            {
                Transform buttonObj = parent.Find(buttonName);
                if (buttonObj != null)
                {
                    if (buttonObj.GetComponent<Button>() != null)
                    {
                        buttonObj.GetComponent<Button>().onClick.AddListener(() =>
                        {
                            action();
                        });
                    }
                    else
                    {
                        Debug.LogError("on the " + buttonObj.name + " cannot find Button Component");
                    }

                }
                else
                {
                    Debug.LogError(buttonName + " path is null");
                    return;
                }
            }
            else
            {
                if (parent.GetComponent<Button>() != null)
                {
                    parent.GetComponent<Button>().onClick.AddListener(() =>
                    {
                        action();
                    });
                }
                else
                {
                    Debug.LogError("on the " + parent.name + " cannot find Button Component");
                }

            }
        }

        /// <summary>
        /// 对象生成在UI自定义层级的父物体下
        /// </summary>
        /// <param name="path"></param>
        /// <param name="parentLayer"></param>
        /// <returns></returns>
        public static Transform SpawnObject(string path, UILayer parentLayer)
        {
            Transform parent = UILayerManager.Instance.UILayerObjDic[parentLayer].transform;
            return SpawnObject(path, parent);
        }

        public static Transform SpawnObject(string path, Transform parent)
        {
            Transform source = Resources.Load<Transform>(path);
            if (source != null)
            {
                return Object.Instantiate(source, parent);
            }
            else
            {
                Debug.LogError("source is null");
                return null;
            }
        }

    }
}
