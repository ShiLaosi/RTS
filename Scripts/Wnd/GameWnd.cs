using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class GameWnd : BasicWnd
{
    const int RowCount = 3;
    const int ColumnCount = 4;



    public override void Initial()
    {
        RectTransform _orderPanelTransform = SelfTransform.Find("OrderPanel") as RectTransform;
        Vector2 rectSize = _orderPanelTransform.rect.size;
        GridLayoutGroup _layout = _orderPanelTransform.GetComponent<GridLayoutGroup>();
        _layout.cellSize = new Vector2(rectSize.x / ColumnCount, rectSize.y / RowCount);

        Transform _infoPanel = _orderPanelTransform.Find("InfoPanel");
        Text _titleText = _infoPanel.Find("TitleText").GetComponent<Text>();
        Text _contentText = _infoPanel.Find("ContentText").GetComponent<Text>();

        SkillBtn[] _allSkils = new SkillBtn[_orderPanelTransform.childCount - 1];

        for (int i = 0; i < _orderPanelTransform.childCount-1; i++)
        {
            GameObject skill = _orderPanelTransform.GetChild(i).gameObject;
            _allSkils[i] = skill.AddComponent<SkillBtn>();
            _allSkils[i].Initial(_infoPanel.gameObject, _titleText, _contentText);
        }

       
        Image _potrait = SelfTransform.Find("Potrait").GetComponent<Image>();
        Transform _dataPanel = SelfTransform.Find("DataPanel");
        Text _nameText = _dataPanel.Find("NameText").GetComponent<Text>();
        Text _dpsText = _dataPanel.Find("DPSText").GetComponent<Text>();
        Text _healthText = _dataPanel.Find("HealthText").GetComponent<Text>();

        HUDManager.Instance.Initial(_potrait, _dataPanel.gameObject, _nameText, _dpsText, _healthText, _orderPanelTransform.gameObject, _allSkils);



    }
}
