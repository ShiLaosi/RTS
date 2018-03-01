using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public enum SkillEnum
{
    闪电链=1001,
    远视,
    召唤狼,
    地震,
    噩梦,
    蚀脑,
    虚弱,
    恶魔的掌握,
    火焰爆轰,
    引燃,
    移动,
    停止,
    攻击,
    巡逻,
    建造_兽族,
    建造_人族,
    建造_不死族,
    建造_暗夜精灵,
    取消命令,
}

public class SkillManager : Singleton<SkillManager>
{
    /// <summary>
    /// 所有技能列表
    /// </summary>
    public Dictionary<SkillEnum, UnityAction<PlayerInfo>> AllSkillsAction { get; private set; }


    public void Initial()
    {
        AllSkillsAction = new Dictionary<SkillEnum, UnityAction<PlayerInfo>>();

        AllSkillsAction.Add(SkillEnum.闪电链, playerInfo =>
        {
            playerInfo.DisplayLowLevelSkills(SkillEnum.闪电链);
        }
        );
        AllSkillsAction.Add(SkillEnum.远视, playerInfo => { Debug.Log("远视"); });
        AllSkillsAction.Add(SkillEnum.召唤狼, playerInfo => { Debug.Log("召唤狼"); });
        AllSkillsAction.Add(SkillEnum.地震, playerInfo => { Debug.Log("地震"); });
        AllSkillsAction.Add(SkillEnum.噩梦, playerInfo => { Debug.Log("噩梦"); });
        AllSkillsAction.Add(SkillEnum.蚀脑, playerInfo => { Debug.Log("蚀脑"); });
        AllSkillsAction.Add(SkillEnum.虚弱, playerInfo => { Debug.Log("虚弱"); });
        AllSkillsAction.Add(SkillEnum.恶魔的掌握, playerInfo => { Debug.Log("恶魔的掌握"); });
        AllSkillsAction.Add(SkillEnum.火焰爆轰, playerInfo => { GameObject.Destroy(playerInfo.gameObject); });
        AllSkillsAction.Add(SkillEnum.引燃, playerInfo => { Debug.Log("引燃"); });
        AllSkillsAction.Add(SkillEnum.移动, playerInfo => { Debug.Log("移动"); });
        AllSkillsAction.Add(SkillEnum.停止, playerInfo => { Debug.Log("停止"); });
        AllSkillsAction.Add(SkillEnum.攻击, playerInfo => { Debug.Log("攻击"); });
        AllSkillsAction.Add(SkillEnum.巡逻, playerInfo => { Debug.Log("巡逻"); });
        AllSkillsAction.Add(SkillEnum.建造_兽族, playerInfo => { Debug.Log("建造_兽族"); });
        AllSkillsAction.Add(SkillEnum.建造_人族, playerInfo => { playerInfo.DisplayLowLevelSkills(SkillEnum.建造_人族); });
        AllSkillsAction.Add(SkillEnum.建造_不死族, playerInfo => { Debug.Log("建造_不死族"); });
        AllSkillsAction.Add(SkillEnum.取消命令, playerInfo => playerInfo.DisplayInfo());


    }

}
