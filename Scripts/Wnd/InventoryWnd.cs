using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class InventoryWnd : BasicWnd
{
    public override void Initial()
    {
        Transform _goods = SelfTransform.Find("Goods");
        InvBtn[] _allInvBtns = new InvBtn[_goods.childCount];
        for (int i = 0; i < _allInvBtns.Length; i++)
        {
            GameObject invObj = _goods.GetChild(i).gameObject;
            _allInvBtns[i] = invObj.AddComponent<InvBtn>();
        }

        Transform _infoPanel = SelfTransform.Find("InfoPanel");
        Text _titleText = _infoPanel.Find("TitleText").GetComponent<Text>();
        Text _infoText = _infoPanel.Find("InfoText").GetComponent<Text>();
        Transform _orderPanel = SelfTransform.Find("OrderPanel");
        GameObject _useBtn = _orderPanel.Find("UseBtn").gameObject;
        GameObject _dropBtn = _orderPanel.Find("DropBtn").gameObject;
        GameObject _cancelBtn = _orderPanel.Find("CancelBtn").gameObject;
        _useBtn.AddComponent<TxtBtn>().Initial(()=>Debug.Log("Use"), Color.red);
        _dropBtn.AddComponent<TxtBtn>().Initial(()=>Debug.Log("Drop"), Color.red);
        _cancelBtn.AddComponent<TxtBtn>().Initial(()=>Debug.Log("Cancel"), Color.red);

        HUDManager.Instance.InitialInv(_allInvBtns, _infoPanel.gameObject, _titleText, _infoText, _orderPanel.gameObject);


    }
}
