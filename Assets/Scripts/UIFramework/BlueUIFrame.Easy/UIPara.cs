using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlueUIFrame.Easy
{
    public interface IPara
    {

    }

    public class UIPara<T> : IPara
    {
        public T Para { get; private set; }
        public UIPara(T para)
        {
            Para = para;
        }
    }

    public class UIPara<T, U> : IPara
    {
        public T Para1 { get; private set; }
        public U Para2 { get; private set; }
        public UIPara(T para1, U para2)
        {
            Para1 = para1;
            Para2 = para2;
        }
    }

    public class UIPara<T, U, V> : IPara
    {
        public T Para1 { get; private set; }
        public U Para2 { get; private set; }
        public V Para3 { get; private set; }
        public UIPara(T para1, U para2, V para3)
        {
            Para1 = para1;
            Para2 = para2;
            Para3 = para3;
        }
    }

    public class UIPara : IPara
    {
        public object[] Paras { get; private set; }
        public UIPara(params object[] paras)
        {
            Paras = paras;
        }
    }
}

