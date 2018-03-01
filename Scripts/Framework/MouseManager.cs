using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

/// <summary>
/// 鼠标操作，基本包括玩家单位的所有操作
/// </summary>
public class MouseManager : MonoBehaviour {

    [SerializeField]
    Material _rectMat;
    [SerializeField]
    Color _rectColor;

    Ray _mouseRay;
    RaycastHit _mouseHitInfo;
    Camera _mouseCamera;

    bool isDrawing;
    Vector3 _startPos;
    bool isSingleSelect;

    void Start () {
        _mouseCamera = Camera.main;
	}
	
	void Update () {

        if (Input.GetKeyDown(KeyCode.I))
        {
            UIManager.Instance.OpenOrCloseWnd<InventoryWnd>();
        }

        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {

            SingleSelect();
            isDrawing = true;
            _startPos = Input.mousePosition;
        }


        if (Input.GetMouseButtonUp(0))
        {
            isDrawing = false;
            CheckSelection();
        }


        if (Input.GetMouseButtonDown(1))
        {
            Move();
        }

       

	}

    void CheckSelection()
    {
        if (isSingleSelect)
        {
            return;
        }

        Vector3 endPos = Input.mousePosition;
        Vector3 start = Vector3.zero;
        Vector3 end = Vector3.zero;
        if (_startPos.x> endPos.x)
        {
            start.x = endPos.x;
            end.x = _startPos.x;
        }
        else
        {
            start.x = _startPos.x;
            end.x = endPos.x;
        }
        if (_startPos.y>endPos.y)
        {
            start.y = endPos.y;
            end.y = _startPos.y;
        }
        else
        {
            start.y = _startPos.y;
            end.y = endPos.y;
        }

        UnitManager.Instance.DisSelectAllPlayers();

        foreach (var player in UnitManager.Instance.AllPlayers)
        {
            Vector3 playerScreenPos = _mouseCamera.WorldToScreenPoint
                (player.transform.position);
            if (playerScreenPos.x>=start.x&&playerScreenPos.x<=end.x&&playerScreenPos.y>=start.y&&playerScreenPos.y<=end.y)
            {
                player.MultipleSelect();
            }
        }


    }


    void Move()
    {
        _mouseRay = _mouseCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(_mouseRay,out _mouseHitInfo))
        {
            //遍历所有可用玩家单位，检测是否被选中，若选中，则移动
            foreach (var player in UnitManager.Instance.AllPlayers)
            {
                if (player.IsSelected)
                {
                    PlayerMove playerMove = player.GetComponent<PlayerMove>();
                    playerMove.Move(_mouseHitInfo.point);
                }
            }
        }
    }


    private void OnPostRender()
    {
        if (!isDrawing)
        {
            return;
        }

        _rectMat.SetPass(0);
        GL.PushMatrix();
        GL.LoadOrtho();
        GL.Begin(GL.LINES);
        GL.Color(_rectColor);

        //左边
        GL.Vertex(GetPercentPos(_startPos));
        GL.Vertex(GetPercentPos(new Vector3(_startPos.x, Input.mousePosition.y, 0)));
        //上边
        GL.Vertex(GetPercentPos(_startPos));
        GL.Vertex(GetPercentPos(new Vector3(Input.mousePosition.x, _startPos.y, 0)));
        //下边
        GL.Vertex(GetPercentPos(new Vector3(_startPos.x, Input.mousePosition.y, 0)));
        GL.Vertex(GetPercentPos(Input.mousePosition));
        //右边
        GL.Vertex(GetPercentPos(new Vector3(Input.mousePosition.x, _startPos.y, 0)));
        GL.Vertex(GetPercentPos(Input.mousePosition));

        GL.End();
        GL.PopMatrix();
    }

    Vector3 GetPercentPos(Vector3 realPos)
    {
        return new Vector3(realPos.x / Screen.width, realPos.y / Screen.height, 0);
    }

    /// <summary>
    /// 单选
    /// </summary>
    void SingleSelect()
    {
        isSingleSelect = false;
        _mouseRay = _mouseCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(_mouseRay, out _mouseHitInfo))
        {
            PlayerSelect player = _mouseHitInfo.transform.GetComponent<PlayerSelect>();//获取射线检测到的目标物体身上的PlayerSelect脚本，如果有，说明这是可选择单位
            if (player != null)
            {
                isSingleSelect = true;
                player.SingleSelect();
            }
        }
    }





}
