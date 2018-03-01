using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using UnityEngine.Events;

public struct CampsInfo
{
    public List<CampInfo> AllCamps;
}

public struct CampInfo
{
    public string Title;
    public string LText;
    public string RText;
    public bool IsActive;
    public string SceneName;
}

/// <summary>
/// 角色的技能信息
/// </summary>
public struct UnitSkillInfo
{
    /// <summary>
    /// 表示所处技能栏的位置
    /// </summary>
    public int SkillBtnIndex;
    /// <summary>
    /// 技能ID
    /// </summary>
    public int SkillID;
    /// <summary>
    /// 技能名称
    /// </summary>
    public string SkillName;
    /// <summary>
    /// 技能说明
    /// </summary>
    public string SkillInfo;
    /// <summary>
    /// 技能图标
    /// </summary>
    public Sprite SkillSprite;
    /// <summary>
    /// 技能执行的操作
    /// </summary>
    public UnityAction<PlayerInfo> SkillAction;
    /// <summary>
    /// 父级技能ID
    /// </summary>
    public int[] ParentSkillID;


}

/// <summary>
/// 配合Json使用的类，存储着从Json中读取到的数据
/// </summary>
public struct JsonUnitInfo
{
    public string Potrait;
    public string Name;
    public int MinDPS;
    public int MaxDPS;
    public int MaxHealth;
    public List<JsonSkill> Skills;
}

/// <summary>
/// 配合Json用的技能类
/// </summary>
public struct JsonSkill
{
    public int SkillBtnIndex;
    public int SkillID;
    public int[] ParentSkillID;
}

public struct AllSkillsInfo
{
    public SingleSkillInfo[] Skills;
}

public struct SingleSkillInfo
{
    public int SkillID;
    public string SkillName;
    public int SkillSpriteIndex;
    public string SkillInfo;
}



public class ConfigManager : Singleton<ConfigManager> {

    Sprite[] _allSkillsSprite;
    AllSkillsInfo _allSkillsInfo;
    /// <summary>
    /// 获取所有需要用到的技能图标
    /// </summary>
    public void Initial()
    {
        _allSkillsSprite = Resources.LoadAll<Sprite>("Sprite/Skills");

        TextAsset allSkillsAsset = Resources.Load<TextAsset>("Config/SkillInfo");
        _allSkillsInfo = JsonMapper.ToObject<AllSkillsInfo>(allSkillsAsset.text);

    }

    public void GetUnitInfo(string objName, out Sprite potrait, out string unitName, out int minDPS, out int maxDPS, out int maxHealth, out List<UnitSkillInfo> allSkills)
    {
        TextAsset textAsset = Resources.Load<TextAsset>("Config/UnitInfo/" + objName);
        JsonUnitInfo jsonUnitInfo = JsonMapper.ToObject<JsonUnitInfo>(textAsset.text);
        potrait = Resources.Load<Sprite>("Sprite/Potrait/" + jsonUnitInfo.Potrait);
        unitName = jsonUnitInfo.Name;
        minDPS = jsonUnitInfo.MinDPS;
        maxDPS = jsonUnitInfo.MaxDPS;
        maxHealth = jsonUnitInfo.MaxHealth;
        allSkills = new List<UnitSkillInfo>();

        //遍历读取到的技能图标序列号，获取技能图标
        foreach (var jsonSkillInfo in jsonUnitInfo.Skills)
        {
            UnitSkillInfo newSkillInfo = new UnitSkillInfo
            {
                SkillBtnIndex = jsonSkillInfo.SkillBtnIndex,
                SkillID = jsonSkillInfo.SkillID,
                ParentSkillID = jsonSkillInfo.ParentSkillID
            };
            foreach (var skillInfo in _allSkillsInfo.Skills)
            {
                if (skillInfo.SkillID == newSkillInfo.SkillID)
                {
                    newSkillInfo.SkillName = skillInfo.SkillName;
                    newSkillInfo.SkillInfo = skillInfo.SkillInfo;
                    newSkillInfo.SkillSprite = _allSkillsSprite[skillInfo.SkillSpriteIndex];
                    SkillEnum newSkillEnum = (SkillEnum)newSkillInfo.SkillID;
                    newSkillInfo.SkillAction = SkillManager.Instance.AllSkillsAction[newSkillEnum];
                    allSkills.Add(newSkillInfo);
                    break;
                }
            }

        }

    }




}
