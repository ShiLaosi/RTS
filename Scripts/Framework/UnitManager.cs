using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitManager : Singleton<UnitManager>
{

    /// <summary>
    /// 存储所有可操控的玩家单位
    /// </summary>
    public List<PlayerSelect> AllPlayers { get; private set; }


    public void Initial()
    {
        AllPlayers = new List<PlayerSelect>();
    }


    /// <summary>
    /// 提供一个方法，玩家单位一出生调用
    /// </summary>
    /// <param name="newPlayer">新生玩家单位</param>
    public void AddPlayer(PlayerSelect newPlayer)
    {
        AllPlayers.Add(newPlayer);
    }


    /// <summary>
    /// 玩家单位被销毁时调用
    /// </summary>
    /// <param name="oldPlayer">要销毁的玩家单位</param>
    public void RemovePlayer(PlayerSelect oldPlayer)
    {
        AllPlayers.Remove(oldPlayer);
    }

    /// <summary>
    /// 取消所有玩家单位的选择
    /// </summary>
    public void DisSelectAllPlayers()
    {
        foreach (var player in AllPlayers)
        {
            player.DisSelect();
        }
        HUDManager.Instance.ClearHUD();
    }
}
