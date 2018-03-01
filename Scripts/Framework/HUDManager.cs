using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class HUDManager : Singleton<HUDManager> {

    #region 人物信息和技能
    GameObject _dataPanel;
    Image _potrait;
    Text _nameText;
    Text _dpsText;
    Text _healthText;
    GameObject _orderPanel;
    SkillBtn[] _allSkills;
    #endregion

    #region 背包
    InvBtn[] _allInvBtns;
    GameObject _invInfoPanel;
    Text _invTitleText;
    Text _invInfoText;
    GameObject _invOrderPanel;

    #endregion


    /// <summary>
    /// 初始化工作，存储所有需要更改的界面元素
    /// </summary>
    /// <param name="potrait">头像</param>
    /// <param name="dataPanel">数据部分</param>
    /// <param name="nameText">名称</param>
    /// <param name="dpsText">攻击力</param>
    /// <param name="healthText">血</param>
    /// <param name="orderPanel">技能栏</param>
    /// <param name="allSkills">所有技能图标</param>
    public void Initial(Image potrait,GameObject dataPanel, Text nameText,Text dpsText,Text healthText,GameObject orderPanel, SkillBtn[] allSkills)
    {
        _potrait = potrait;
        _dataPanel = dataPanel;
        _nameText = nameText;
        _dpsText = dpsText;
        _healthText = healthText;
        _orderPanel = orderPanel;
        _allSkills = allSkills;
    }


    /// <summary>
    /// 初始化背包
    /// </summary>
    /// <param name="allInvBtns">所有物品的功能类</param>
    /// <param name="invInfoPanel">物品信息面板</param>
    /// <param name="invTitleText">物品名称</param>
    /// <param name="invInfoText">物品说明</param>
    /// <param name="invOrderPanel">物品操作面板</param>
    public void InitialInv(InvBtn[] allInvBtns,GameObject invInfoPanel,Text invTitleText,Text invInfoText,GameObject invOrderPanel)
    {
        _allInvBtns = allInvBtns;
        _invInfoPanel = invInfoPanel;
        _invTitleText = invTitleText;
        _invInfoText = invInfoText;
        _invOrderPanel = invOrderPanel;
    }


    public void DisplayInvInfo()
    {
        _invInfoPanel.SetActive(true);
    }

    public void DisplayInvOrder()
    {
        _invOrderPanel.SetActive(true);
    }

    public void HideInvInfo()
    {
        _invInfoPanel.SetActive(false);
    }

    public void HideInvOrder()
    {
        _invOrderPanel.SetActive(false);
    }


    /// <summary>
    /// 显示HUD
    /// </summary>
    /// <param name="playerInfo">玩家单位信息</param>
    public void DisplayHUD(PlayerInfo playerInfo)
    {
        _potrait.sprite = playerInfo.Potrait;
        _nameText.text = playerInfo.UnitName;
        _dpsText.text = string.Format("{0}-{1}", playerInfo.MinDPS, playerInfo.MaxDPS);
        _healthText.text = string.Format("{0}-{1}", playerInfo.CurrentHealth, playerInfo.MaxHealth);
        _potrait.gameObject.SetActive(true);
        _dataPanel.SetActive(true);
        _orderPanel.SetActive(true);
    }


    public void DisplaySkill(PlayerInfo playerInfo, List<UnitSkillInfo> allSkills)
    {
        ClearSkills();

        //显示技能
        foreach (var skill in allSkills)
        {
            int skillBtnIndex = skill.SkillBtnIndex;
            _allSkills[skillBtnIndex].SetSkill(skill.SkillSprite, skill.SkillName, skill.SkillInfo, skill.SkillAction, playerInfo);
        }
    }


    /// <summary>
    /// 清空技能列表
    /// </summary>
    void ClearSkills()
    {
        foreach (var skill in _allSkills)
        {
            skill.ClearSkill();
        }
    }

    /// <summary>
    /// 清空HUD
    /// </summary>
    public void ClearHUD()
    {
        _potrait.gameObject.SetActive(false);
        _dataPanel.SetActive(false);
        _orderPanel.SetActive(false);
    }

}
