using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIManager : Singleton<UIManager>
{
    Dictionary<string, IScene> _allScenes;
    Dictionary<string, BasicWnd> _allWnds;
    Transform _canvasTransform;
    public Camera UICamera { get; private set; }

    public void Initial(Transform canvasTransform,Camera uiCamera)
    {
        _allScenes = new Dictionary<string, IScene>();
        _allWnds = new Dictionary<string, BasicWnd>();
        _canvasTransform = canvasTransform;
        UICamera = uiCamera;
    }


    /// <summary>
    /// 加载场景
    /// </summary>
    /// <typeparam name="T">场景类</typeparam>
    public void LoadScene<T>() where T:IScene,new()
    {
        string sceneName = typeof(T).Name;
        if (_allScenes.ContainsKey(sceneName))
        {
            _allScenes[sceneName].Initial();
        }
        else
        {
            T scene = new T();
            scene.Initial();
            _allScenes.Add(sceneName, scene);
        }
    }

    /// <summary>
    /// 加载窗口
    /// </summary>
    /// <typeparam name="T">所要加载的窗口所对应的类</typeparam>
    public void LoadWnd<T>() where T:BasicWnd,new()
    {
        string wndName = typeof(T).Name;

        //如果字典中已经存在此窗口的类，则直接克隆预制体
        if (_allWnds.ContainsKey(wndName))
        {
            _allWnds[wndName].LoadWnd(_canvasTransform, wndName);
            _allWnds[wndName].Initial();
        }
        //否则，生成一个新的类
        else
        {
            T wnd = new T();
            wnd.LoadWnd(_canvasTransform, wndName);
            wnd.Initial();
            _allWnds.Add(wndName, wnd);
        }
    }

    /// <summary>
    /// 删除窗口
    /// </summary>
    /// <typeparam name="T">窗口的类</typeparam>
    public void RemoveWnd<T>() where T:BasicWnd
    {
        string wndName = typeof(T).Name;
        if (_allWnds.ContainsKey(wndName))
        {
            _allWnds[wndName].CloseWnd();
        }
    }

    /// <summary>
    /// 删除所有窗口
    /// </summary>
    public void RemoveAllWnds()
    {
        foreach (var wnd in _allWnds)
        {
            wnd.Value.CloseWnd();
        }
    }

    /// <summary>
    /// 打开或关闭窗口，适用于经常开关的窗口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public void OpenOrCloseWnd<T>() where T:BasicWnd
    {
        string wndName = typeof(T).Name;
        if (_allWnds.ContainsKey(wndName))
        {
            _allWnds[wndName].OpenOrClose();
        }
    }




}
