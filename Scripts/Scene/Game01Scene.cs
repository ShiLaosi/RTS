using UnityEngine;
using System.Collections;
using System;

public class Game01Scene : IScene {

    public void Exit()
    {
        
    }

    public void Initial()
    {
        UIManager.Instance.RemoveWnd<LoadingWnd>();
        UIManager.Instance.LoadWnd<GameWnd>();
        UIManager.Instance.LoadWnd<InventoryWnd>();

    }

}
