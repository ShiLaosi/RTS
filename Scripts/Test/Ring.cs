using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using DG.Tweening;

public class Ring : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler {

    RectTransform _contentTransform;
    RectTransform _selfTransform;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Vector2 desPos = -_selfTransform.anchoredPosition;
        _contentTransform.DOAnchorPos(desPos, 1);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
       
    }

    void Start () {
        _selfTransform = transform as RectTransform;
        _contentTransform = transform.parent as RectTransform;
	}
	
}
