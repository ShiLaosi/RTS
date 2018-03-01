using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class LoadingWnd : BasicWnd {

    const float progressTotalTime = 1f;

    Slider progress;

    public override void Initial()
    {
        progress = SelfTransform.Find("Progress").GetComponent<Slider>();
        TimeManager.Instance.BindAction(MakeProgress, progressTotalTime,LoadManager.Instance.LoadScene);
    }

    void MakeProgress()
    {
        progress.value += Time.deltaTime/ progressTotalTime;
    }

    
}
