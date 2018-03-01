using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

/// <summary>
/// 执行方法的类，包括了要执行的方法和执行时间
/// </summary>
public class TimeAction
{
    UnityAction SelfAction;
    UnityAction OnCompleteAction;
    public float TotalTime { get; private set; }
    public TimeAction(UnityAction doAction, float totalTime,UnityAction onCompleteAction)
    {
        SelfAction = doAction;
        TotalTime = totalTime;
        OnCompleteAction = onCompleteAction;
    }

    /// <summary>
    /// 通过此方法，执行要执行的方法，并且每次都把总时间减去一定量
    /// </summary>
    /// <param name="dt">每次的时间，一般为Time.deltaTime</param>
    public void DoAction(float dt)
    {
        TotalTime -= dt;
        if (SelfAction != null)
        {
            SelfAction();
        }
    }

    /// <summary>
    /// 当时间到达后，执行此委托
    /// </summary>
    public void DoCompleteAction()
    {
        if (OnCompleteAction!=null)
        {
            OnCompleteAction();
        }
    }
}

public class TimeManager : Singleton<TimeManager> {

    /// <summary>
    /// 所有要执行的方法
    /// </summary>
    List<TimeAction> _allActions = new List<TimeAction>();

    public void BindAction(UnityAction doAction,float totalTime,UnityAction OnComplete = null)
    {
        TimeAction newTimeAction = new TimeAction(doAction, totalTime,OnComplete);
        _allActions.Add(newTimeAction);
    }

    public void Update(float dt)
    {
        for (int i = 0; i < _allActions.Count; i++)
        {
            if (_allActions[i].TotalTime>0)
            {
                _allActions[i].DoAction(dt);
            }
            else
            {
                _allActions[i].DoCompleteAction();
                _allActions.RemoveAt(i);
            }
        }
    }
}
