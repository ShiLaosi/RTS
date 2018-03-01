using UnityEngine;
using System.Collections;
using DG.Tweening;



public class TestRollManager : MonoBehaviour {

    TestInfoPanel _infoPanel;
    RectTransform _contentRectTransform;
    string _title;
    string _info;
    SkillLevel _skillLevel;

	void Start () {
        _infoPanel = transform.Find("InfoPanel").GetComponent<TestInfoPanel>();
       
        _contentRectTransform = transform.Find("Content") as RectTransform;
	}

    public void RollToPos(Vector2 desPos,string title,string info,SkillLevel skillLevel)
    {
        Tweener onComplete = _contentRectTransform.DOAnchorPos(-desPos, 1);
        _title = title;
        _info = info;
        _skillLevel = skillLevel;
        onComplete.OnComplete(ShowInfo);
    }

    void ShowInfo()
    {
        ShowInfo(_title, _info, _skillLevel);
    }

    public void ShowInfo(string title, string info, SkillLevel skillLevel)
    {
        _infoPanel.DisplayInfo(title, info, skillLevel);
    }
}
