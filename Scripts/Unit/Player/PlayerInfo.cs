using UnityEngine;
using System.Collections;
using LitJson;
using System.Collections.Generic;

public class PlayerInfo : MonoBehaviour
{

    Sprite _potrait;
    string _unitName;
    int _minDPS;
    int _maxDPS;
    int _currentHealth;
    int _maxHealth;
    List<UnitSkillInfo> _allSkills;

    public Sprite Potrait
    {
        get
        {
            return _potrait;
        }

        private set
        {
            _potrait = value;
        }
    }

    public string UnitName
    {
        get
        {
            return _unitName;
        }

        private set
        {
            _unitName = value;
        }
    }

    public int MinDPS
    {
        get
        {
            return _minDPS;
        }

        private set
        {
            _minDPS = value;
        }
    }

    public int MaxDPS
    {
        get
        {
            return _maxDPS;
        }

        private set
        {
            _maxDPS = value;
        }
    }

    public int CurrentHealth
    {
        get
        {
            return _currentHealth;
        }

        private set
        {
            _currentHealth = value;
        }
    }

    public int MaxHealth
    {
        get
        {
            return _maxHealth;
        }

        private set
        {
            _maxHealth = value;
        }
    }

    public List<UnitSkillInfo> AllSkills
    {
        get
        {
            return _allSkills;
        }

        private set
        {
            _allSkills = value;
        }
    }

    public List<UnitSkillInfo> TopLevelSkills
    {
        get
        {
            return _topLevelSkills;
        }

        private set
        {
            _topLevelSkills = value;
        }
    }

    public List<UnitSkillInfo> LowLevelSkills
    {
        get
        {
            return _lowLevelSkills;
        }

        private set
        {
            _lowLevelSkills = value;
        }
    }

    List<UnitSkillInfo> _topLevelSkills;
    List<UnitSkillInfo> _lowLevelSkills;

    void Start()
    {
        ConfigManager.Instance.GetUnitInfo(name, out _potrait, out _unitName, out _minDPS, out _maxDPS, out _maxHealth, out _allSkills);

        TopLevelSkills = _allSkills.FindAll(skill => skill.ParentSkillID.Length == 0);
        LowLevelSkills = _allSkills.FindAll(skill => skill.ParentSkillID.Length != 0);


        CurrentHealth = _maxHealth;
    }



    /// <summary>
    /// 显示次级技能面板
    /// </summary>
    /// <param name="topLevelSkillEnum"></param>
    public void DisplayLowLevelSkills(SkillEnum topLevelSkillEnum)
    {
        List<UnitSkillInfo> tmpSkills = new List<UnitSkillInfo>();
        int topSkillID = (int)topLevelSkillEnum;
        foreach (var lowLevelSkill in LowLevelSkills)
        {
            foreach (var parentID in lowLevelSkill.ParentSkillID)
            {
                if (parentID==topSkillID)
                {
                    tmpSkills.Add(lowLevelSkill);
                    break;
                }
            }
        }
        HUDManager.Instance.DisplaySkill(this, tmpSkills);
    }


    /// <summary>
    /// 公开一个方法，供PlayerSelect调用，以显示HUD
    /// </summary>
    public void DisplayInfo()
    {
        HUDManager.Instance.DisplayHUD(this);
        HUDManager.Instance.DisplaySkill(this, TopLevelSkills);
    }
}
