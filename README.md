# BlueUIFrame
基于UGUI的简易UI框架

1）底层系统类，全局唯一

AUIRoot：是根节点抽象类，负责所有系统的初始化
IUIManager：是UI组件的管理类，提供UI界面显示，返回等统一接口
IUIDataHandlerManager ：是数据处理器管理类，提供对数据处理器的缓存，添加，移除等接口
IUILayerManager ：是UI层级管理类，根据UI预设的层级划分，系统自动设置UI的父物体，利用unity的自然层级管理UI的显示层级
IUIEffectManager ：是UI动效管理类，架构内的动效类与UI系统完全解耦，此类负责管理UI动效的播放，提供UI物体Active状态及对象初始化状态的回调接口
AUIPathManager ：UI路径管理接口，类似与配置文件，需要手动在类的字典UIPathDic里配置路径

2）其他接口

AUIBase ：UI基类，定义了处理UI的状态切换及回调事件等接口
AUIEffect ：UI动效基类，定义了UI动效切换的接口及回调事件
IData :数据基类，用标记类为数据类
DataHandler ：数据处理器接口，定义数据初始化，数据更新接口，此类进行数据的操作

详细说明请查看博客：https://blog.csdn.net/zcaixzy5211314/article/details/80473255
