using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using UnityEngine.Events;

public class TxtBtn : MonoBehaviour,IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler {

    Color _highlightColor;
    Color _normalColor;
    Text _selfText;
    UnityAction onBtnClick;

    public void Initial(UnityAction onBtnClick,Color highlightColor)
    {
        this.onBtnClick = onBtnClick;
        _highlightColor = highlightColor;
    }


    void Start () {
        _selfText = GetComponent<Text>();
        _normalColor = _selfText.color;
	}
	
    public void OnPointerClick(PointerEventData eventData)
    {
        onBtnClick();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _selfText.color = _highlightColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _selfText.color = _normalColor;
    }
}
