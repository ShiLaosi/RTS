using UnityEngine;
using System.Collections;
using System;

public class LobbyScene : IScene
{
    public void Exit()
    {
        
    }

    public void Initial()
    {
        UIManager.Instance.RemoveAllWnds();
        UIManager.Instance.LoadWnd<LobbyWnd>();
    }
}
