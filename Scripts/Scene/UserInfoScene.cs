using UnityEngine;
using System.Collections;

public class UserInfoScene : IScene {

    public void Exit()
    {

    }

    public void Initial()
    {
        UIManager.Instance.RemoveAllWnds();
        UIManager.Instance.LoadWnd<UserInfoWnd>();
    }
}
