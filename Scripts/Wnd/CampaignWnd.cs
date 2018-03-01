using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
using LitJson;

public class CampaignWnd : BasicWnd {

    public override void Initial()
    {
        GameObject back = SelfTransform.Find("Back").gameObject;
        back.AddComponent<TxtBtn>().Initial(OnBackClick, Color.red);

        Transform campsTransform = SelfTransform.Find("Camps");

        GameObject campBtn = campsTransform.Find("CampBtn").gameObject;

        TextAsset config = Resources.Load<TextAsset>("Config/CampInfo");

        CampsInfo allCamps = JsonMapper.ToObject<CampsInfo>(config.text);

        foreach (var camp in allCamps.AllCamps)
        {
            if (camp.IsActive)
            {
                GameObject cloneCampBtn = GameObject.Instantiate(campBtn);
                cloneCampBtn.transform.SetParent(campsTransform, false);
                cloneCampBtn.SetActive(true);
                cloneCampBtn.AddComponent<CampBtn>().Initial(camp.Title, camp.LText, camp.RText, camp.SceneName);
            }
        }

    }

    void OnBackClick()
    {
        SceneManager.LoadScene((int)SceneName.单人模式大厅);
    }

   
}
