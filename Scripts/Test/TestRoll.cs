using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class TestRoll : MonoBehaviour ,IPointerEnterHandler,IPointerExitHandler{

    TestRollManager _manager;
    RectTransform _selfRectTransform;
    Image _selfImage;

    // Use this for initialization
    void Start()
    {
        _selfImage = GetComponent<Image>();
        _selfRectTransform = transform as RectTransform;
        _manager = transform.parent.parent.GetComponent<TestRollManager>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _selfImage.color = Color.red;
        //_manager.RollToPos(_selfRectTransform.anchoredPosition);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _selfImage.color = Color.white;

    }


}
