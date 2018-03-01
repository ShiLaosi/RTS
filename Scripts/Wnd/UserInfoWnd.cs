using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class UserInfoWnd : BasicWnd
{
    #region 登录界面UI元素
    GameObject _loginObj;
    InputField _loginUserName;
    InputField _loginPwd;
    Text _loginTip;
    #endregion


    #region 注册界面UI元素
    GameObject _registObj;
    InputField _registUserName;
    InputField _registPwd;
    InputField _registRePwd;
    Text _registTip;
    #endregion



    public override void Initial()
    {
        _loginObj = SelfTransform.Find("Login").gameObject;
        _loginUserName = _loginObj.transform.Find("UserName/InputField").GetComponent<InputField>();
        _loginPwd = _loginObj.transform.Find("UserPwd/InputField").GetComponent<InputField>();
        _loginTip = _loginObj.transform.Find("Tip").GetComponent<Text>();
        GameObject loginBtn = _loginObj.transform.Find("LoginBtn").gameObject;
        GameObject loginRegistBtn = _loginObj.transform.Find("RegistBtn").gameObject;
        loginBtn.AddComponent<TxtBtn>().Initial(OnLoginBtnClick, Color.blue);
        loginRegistBtn.AddComponent<TxtBtn>().Initial(OnLoginRegistBtnClick, Color.red);

        _registObj = SelfTransform.Find("Regist").gameObject;
        _registUserName = _registObj.transform.Find("UserName/InputField").GetComponent<InputField>();
        _registPwd = _registObj.transform.Find("UserPwd/InputField").GetComponent<InputField>();
        _registRePwd = _registObj.transform.Find("RePwd/InputField").GetComponent<InputField>();
        _registTip = _registObj.transform.Find("Tip").GetComponent<Text>();
        GameObject registBtn = _registObj.transform.Find("RegistBtn").gameObject;
        GameObject backBtn = _registObj.transform.Find("BackBtn").gameObject;
        registBtn.AddComponent<TxtBtn>().Initial(OnRegistBtnClick, Color.red);
        backBtn.AddComponent<TxtBtn>().Initial(OnBackBtnClick, Color.blue);

    }

    void OnLoginBtnClick()
    {
        string userName = _loginUserName.text;
        string pwd = _loginPwd.text;
        if (UserInfoHandler.Instance.Login(userName,pwd))
        {
            _loginTip.text = "登录成功！";
        }
        else
        {
            _loginTip.text = "用户名或密码错误！";
        }


       
    }

    void OnLoginRegistBtnClick()
    {
        _loginUserName.text = "";
        _loginPwd.text = "";
        _loginTip.text = "";
        _loginObj.SetActive(false);
        _registObj.SetActive(true);
    }

    void OnRegistBtnClick()
    {
        //先注册，然后返回
        string pwd = _registPwd.text;
        string rePwd = _registRePwd.text;
        if (pwd!=rePwd)
        {
            _registTip.text = "两次输入密码不一致！";
            return;
        }

        string userName = _registUserName.text;
        if (UserInfoHandler.Instance.Regist(userName,pwd))
        {
            _registTip.text = "注册成功！";
            TimeManager.Instance.BindAction(null, 1, OnBackBtnClick);
        }
        else
        {
            _registTip.text = "该用户名已存在！";
        }

    }

    void OnBackBtnClick()
    {
        _registUserName.text = "";
        _registPwd.text = "";
        _registRePwd.text = "";
        _registTip.text = "";
        _registObj.SetActive(false);
        _loginObj.SetActive(true);
    }
}
