using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class LobbyWnd : BasicWnd
{
    public override void Initial()
    {
        GameObject camp = SelfTransform.Find("Campaign").gameObject;
        GameObject encounter = SelfTransform.Find("Encounter").gameObject;
        GameObject back = SelfTransform.Find("Back").gameObject;
        camp.AddComponent<TxtBtn>().Initial(OnCampClick, Color.green);
        encounter.AddComponent<TxtBtn>().Initial(OnEncounterClick, Color.yellow);
        back.AddComponent<TxtBtn>().Initial(OnBackClick, Color.red);
    }

    void OnCampClick()
    {
        SceneManager.LoadScene((int)SceneName.关卡选择);
    }

    void OnEncounterClick()
    {

    }

    void OnBackClick()
    {
        SceneManager.LoadScene((int)SceneName.欢迎);
    }
}
