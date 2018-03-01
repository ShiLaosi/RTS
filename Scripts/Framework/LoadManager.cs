using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadManager : Singleton<LoadManager> {

    string _currentSceneName;

    /// <summary>
    /// 先加载过渡场景，然后再加载想要的场景
    /// </summary>
    /// <param name="sceneName"></param>
    public void LoadScene(string sceneName)
    {
        _currentSceneName = sceneName;
        SceneManager.LoadScene((int)SceneName.加载);

        UnitManager.Instance.Initial();
        ConfigManager.Instance.Initial();
        SkillManager.Instance.Initial();
    }


    public void LoadScene()
    {
        UIManager.Instance.UICamera.clearFlags = CameraClearFlags.Depth;
        SceneManager.LoadScene(_currentSceneName);
    }


}
