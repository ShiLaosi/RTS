using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using DG.Tweening;
public class RingWnd : MonoBehaviour, IPointerEnterHandler {

    RectTransform _contentTransform;
    RectTransform _selfTransform;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Vector2 desPos = -_selfTransform.anchoredPosition;
        _contentTransform.DOAnchorPos(desPos, 2);
    }

    void Start () {
        _selfTransform = transform as RectTransform;
        _contentTransform = transform.parent as RectTransform;

        
	}
	

	void Update () {
	


	}
}
