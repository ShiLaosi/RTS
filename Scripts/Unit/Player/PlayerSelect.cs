using UnityEngine;
using System.Collections;
using HighlightingSystem;

/// <summary>
/// 玩家单位选择，控制玩家单位是否执行操作
/// </summary>
public class PlayerSelect : MonoBehaviour {

    Color _highlightColor = Color.green;
    Highlighter _selfHighlight;
    PlayerInfo _selfInfo;
    bool isSelected;

    public bool IsSelected
    {
        get;
        private set;
    }


    void Start () {
        _selfInfo = GetComponent<PlayerInfo>();
        _selfHighlight = GetComponent<Highlighter>();
        UnitManager.Instance.AddPlayer(this);//将自身加入队列中
	}
	
	void Update () {
        if (IsSelected)
        {
            _selfHighlight.On(_highlightColor);
        }
    }

    /// <summary>
    /// 单选，先清楚所有已选择单位，然后选择自己，显示自己的HUD
    /// </summary>
    public void SingleSelect()
    {
        UnitManager.Instance.DisSelectAllPlayers();
        IsSelected = true;
        _selfInfo.DisplayInfo();
    }

    /// <summary>
    /// 多选，不会清楚已选择单位
    /// </summary>
    public void MultipleSelect()
    {
        IsSelected = true;
    }

    /// <summary>
    /// 提供方法，供UnitManager调用，以便取消选择
    /// </summary>
    public void DisSelect()
    {
        IsSelected = false;
    }
}
