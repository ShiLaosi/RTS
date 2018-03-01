using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class InvBtn : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerClickHandler {

    Image _selfImage;
    Text _countText;
    int _invCount;
    Sprite _originSprite;


    void Start()
    {
        _selfImage = GetComponent<Image>();
        _originSprite = _selfImage.sprite;
        _countText = transform.Find("Text").GetComponent<Text>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("使用中");
        }
    }

    public void SetInv(Sprite invSprite)
    {
        _selfImage.sprite = invSprite;
    }

    public void ClearInv()
    {
        _selfImage.sprite = _originSprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        HUDManager.Instance.DisplayInvOrder();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        HUDManager.Instance.DisplayInvInfo();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        HUDManager.Instance.HideInvInfo();
    }

   
}
