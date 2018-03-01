using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class WelcomeWnd : BasicWnd
{
    public override void Initial()
    {
        GameObject single = SelfTransform.Find("Single").gameObject;
        GameObject multiple = SelfTransform.Find("Multiple").gameObject;
        GameObject exit = SelfTransform.Find("Exit").gameObject;
        single.AddComponent<TxtBtn>().Initial(OnSingleBtnClick, Color.red);
        multiple.AddComponent<TxtBtn>().Initial(OnMultipleBtnClick, Color.green);
        exit.AddComponent<TxtBtn>().Initial(Application.Quit, Color.blue);
    }


    void OnSingleBtnClick()
    {
        SceneManager.LoadScene((int)SceneName.单人模式大厅);
    }

    void OnMultipleBtnClick()
    {
        SceneManager.LoadScene((int)SceneName.网络模式_登录界面);
    }
}
