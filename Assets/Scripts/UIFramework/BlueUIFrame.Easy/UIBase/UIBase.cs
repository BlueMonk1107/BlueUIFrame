//=======================================================
// 作者：BlueMonk
// 描述：基于UGUI的简易UI框架
//=======================================================
using System;
using UnityEngine;
using System.Collections;
using Object = UnityEngine.Object;

namespace BlueUIFrame.Easy
{
    /// <summary>
    /// UI基础类
    /// <para>
    /// UI基础处理的实现
    /// </para>
    /// </summary>
    public class UIBase : AUIBase
    {
        /// <summary>
        /// 当前UI的数据处理器
        /// </summary>
        protected IDataHandler dataHandler;
        /// <summary>
        /// 当前UI的状态
        /// </summary>
        private UIStateEnum uiState;
        /// <summary>
        /// 初始化函数的回调
        /// </summary>
        private Func<Object, bool> InitAction;
        /// <summary>
        /// 对象显示或隐藏状态的回调
        /// </summary>
        private Func<bool, bool> ObjectActiveAction;
        /// <summary>
        /// 初始化UI
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dataHandlerName"></param>
        protected void InitUI(EUiId id, string dataHandlerName = null)
        {
            ID = id;
            uiState = UIStateEnum.NOTINIT;
            if (!string.IsNullOrEmpty(dataHandlerName))
            {
                dataHandler = GetDataHandlerManager().GetHandler(dataHandlerName);
                dataHandler.UpdateShow += UpdateShow;
            }
        }
        /// <summary>
        /// 设置UI状态
        /// </summary>
        /// <param name="state"></param>
        protected override void SetUIState(UIStateEnum state)
        {
            HandleState(uiState, state);
            uiState = state;
        }
        /// <summary>
        /// 获取UI状态
        /// </summary>
        /// <returns></returns>
        protected override UIStateEnum GetUIState()
        {
            return uiState;
        }
        /// <summary>
        /// UI状态的处理函数
        /// </summary>
        /// <param name="currentState"></param>
        /// <param name="targetState"></param>
        protected override void HandleState(UIStateEnum currentState, UIStateEnum targetState)
        {
            switch (targetState)
            {
                case UIStateEnum.INIT:
                    Init();
                    break;
                case UIStateEnum.SHOW:
                    if (currentState == UIStateEnum.NOTINIT)
                    {
                        Init();
                        Show();
                    }
                    else
                    {
                        Show();
                    }
                    break;
                case UIStateEnum.HIDE:
                    Hide();
                    break;
            }
        }

        protected virtual void Init()
        {
            if (InitAction != null)
            {
                InitAction(gameObject);
            }
        }

        protected virtual void Show()
        {
            UpdateShow();
            SetActive(true);
        }

        protected virtual void Hide()
        {
            SetActive(false);
        }
        /// <summary>
        /// 刷新UI显示
        /// </summary>
        protected virtual void UpdateShow()
        {
        }
        /// <summary>
        /// 添加初始化监听
        /// </summary>
        /// <param name="action"></param>
        public override void AddInitListener(Func<Object, bool> action)
        {
            InitAction = action;
        }
        /// <summary>
        /// 添加显示或隐藏状态监听
        /// </summary>
        /// <param name="action"></param>
        public override void AddActiveListener(Func<bool, bool> action)
        {
            ObjectActiveAction = action;
        }
        /// <summary>
        /// 获取当前UI层级
        /// </summary>
        /// <returns></returns>
        public override UILayer GetLayer()
        {
            throw new System.NotImplementedException();
        }

        protected override IUIDataHandlerManager GetDataHandlerManager()
        {
            return AUIRoot.DataHandlerManager;
        }
        /// <summary>
        /// 设置当前对象显示或隐藏
        /// </summary>
        /// <param name="isShow"></param>
        protected override void SetActive(bool isShow)
        {
            try
            {
                if (ObjectActiveAction == null)
                {
                    gameObject.SetActive(isShow);
                }
                else
                {
                    if (!ObjectActiveAction(isShow))
                    {
                        gameObject.SetActive(isShow);
                    }
                }
            }
            catch (Exception)
            {
                Debug.LogError(gameObject.name+ " ObjectActiveAction has ERROR");
                gameObject.SetActive(isShow);
            }
            
        }
        /// <summary>
        /// 获取当前UI的数据类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected virtual T GetData<T>() where T : IData
        {
            if (dataHandler == null)
            {
                throw new Exception("This dataHandler is null." +
                                    "Please call the InitUI method in the Init method" +
                                    " to initialize the dataHandler");
            }
            return (T)dataHandler.GetData();
        }
    }

    public enum UIStateEnum
    {
        NOTINIT,
        INIT,
        SHOW,
        HIDE
    }
}
