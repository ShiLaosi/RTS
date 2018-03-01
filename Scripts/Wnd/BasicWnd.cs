using UnityEngine;
using System.Collections;

public abstract class BasicWnd  {

    protected Transform SelfTransform { get; private set; }
	
    /// <summary>
    /// 加载窗口
    /// </summary>
    /// <param name="canvasTransform">Canvas的Transform，否则UGUI无法显示</param>
    /// <param name="wndName">窗口的预制体的名称</param>
    public void LoadWnd(Transform canvasTransform,string wndName)
    {
        GameObject originWnd = Resources.Load<GameObject>("Wnd/" + wndName);
        GameObject cloneWnd = GameObject.Instantiate(originWnd);
        SelfTransform = cloneWnd.transform;
        SelfTransform.SetParent(canvasTransform, false);

    }

    /// <summary>
    /// 初始化窗口
    /// </summary>
    public abstract void Initial();

    /// <summary>
    /// 删除窗口
    /// </summary>
    public void CloseWnd()
    {
        if (SelfTransform != null)
        {
            GameObject.Destroy(SelfTransform.gameObject);
        }
    }


    /// <summary>
    /// 经常开关的窗口用
    /// </summary>
    public void OpenOrClose()
    {
        Debug.Log(SelfTransform.gameObject.activeSelf);
        SelfTransform.gameObject.SetActive(!SelfTransform.gameObject.activeSelf);
    }



}
