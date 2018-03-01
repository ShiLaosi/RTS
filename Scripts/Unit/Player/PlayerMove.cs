using UnityEngine;
using System.Collections;

/// <summary>
/// 玩家单位移动，本身不会执行操作，由MouseManager执行
/// </summary>
public class PlayerMove : MonoBehaviour {

    NavMeshAgent _agent;

	void Start () {
        _agent = GetComponent<NavMeshAgent>();
	}
	
    public void Move(Vector3 desPos)
    {
        _agent.SetDestination(desPos);
    }
}
