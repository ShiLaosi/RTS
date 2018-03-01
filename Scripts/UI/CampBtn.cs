using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class CampBtn : MonoBehaviour ,IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler{

    Image _selfImage;
    Text _title;
    Text _lText;
    Text _rText;
    string _sceneName;


    public void Initial(string title,string lText,string rText,string sceneName)
    {
        _title = transform.Find("CampText").GetComponent<Text>();
        _lText = transform.Find("LText").GetComponent<Text>();
        _rText = transform.Find("RText").GetComponent<Text>();
        _title.text = title;
        _lText.text = lText;
        _rText.text = rText;
        _sceneName = sceneName;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        LoadManager.Instance.LoadScene(_sceneName);
    }

   



    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }
}
