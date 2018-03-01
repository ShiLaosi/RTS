using UnityEngine;
using System.Collections;
using LitJson;

public enum SceneName
{
    加载 = 0,
    欢迎 = 2,
    网络模式_登录界面,
    单人模式大厅,
    关卡选择,
    关卡1,
    关卡2,
    关卡3,
    关卡4,
    关卡5
}

public class GameManager : MonoBehaviour {

	void Start () {

        Transform _canvasTransform = transform.Find("UICanvas");

        Camera _uiCamera = transform.Find("UICamera").GetComponent<Camera>();

        UIManager.Instance.Initial(_canvasTransform, _uiCamera);

        UIManager.Instance.LoadWnd<WelcomeWnd>();

        DontDestroyOnLoad(this);
        

	}

    private void OnLevelWasLoaded(int level)
    {
        SceneName currentScene = (SceneName)level;

        switch (currentScene)
        {
            case SceneName.加载:
                UIManager.Instance.LoadScene<LoadingScene>();
                break;
            case SceneName.欢迎:
                UIManager.Instance.LoadScene<WelcomeScene>();
                break;
            case SceneName.网络模式_登录界面:
                UIManager.Instance.LoadScene<UserInfoScene>();
                break;
            case SceneName.单人模式大厅:
                UIManager.Instance.LoadScene<LobbyScene>();
                break;
            case SceneName.关卡选择:
                UIManager.Instance.LoadScene<CampaignScene>();
                break;
            case SceneName.关卡1:
                UIManager.Instance.LoadScene<Game01Scene>();
                break;
            case SceneName.关卡2:
                break;
            case SceneName.关卡3:
                break;
            case SceneName.关卡4:
                break;
            case SceneName.关卡5:
                break;
           
        }
    }

    void Update () {
        TimeManager.Instance.Update(Time.deltaTime);
	}
}
