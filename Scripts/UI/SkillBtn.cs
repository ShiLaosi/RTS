using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;
using UnityEngine.Events;

public class SkillBtn : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerClickHandler {

    GameObject _infoPanel;
    Text _titleText;
    Text _contentText;
    Image _selfImage;
    string _title;
    string _content;
    UnityAction<PlayerInfo> _skillAction;
    PlayerInfo _playerInfo;


    public void Initial(GameObject infoPanel,Text titleText,Text contentText)
    {
        _infoPanel = infoPanel;
        _titleText = titleText;
        _contentText = contentText;
        _selfImage = GetComponent<Image>();
    }

    public void SetSkill(Sprite selfSprite,string title,string content, UnityAction<PlayerInfo> skillAction,PlayerInfo playerInfo)
    {
        _selfImage.sprite = selfSprite;
        _selfImage.color = Color.white;
        _title = title;
        _content = content;
        _skillAction = skillAction;
        _playerInfo = playerInfo;
    }

    public void ClearSkill()
    {
        _selfImage.color = Color.clear;
    }




    public void OnPointerClick(PointerEventData eventData)
    {
        _skillAction(_playerInfo);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_selfImage.color==Color.clear)
        {
            return;
        }
        _infoPanel.SetActive(true);
        _titleText.text = _title;
        _contentText.text = _content;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _infoPanel.SetActive(false);
    }
}
