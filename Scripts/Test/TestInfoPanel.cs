using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum SkillLevel
{
    普通,
    白银,
    黄金,
    白金,
    黑金
}

public class TestInfoPanel : MonoBehaviour {

     Color[] levelColors = new Color[] { Color.white, Color.grey, Color.yellow, Color.green, Color.cyan };
    Text _title;
    Text _info;

	void Start () {
        _title = transform.Find("Title").GetComponent<Text>();
        _info = transform.Find("Info").GetComponent<Text>();
	}

    public void DisplayInfo(string title, string info, SkillLevel skillLevel)
    {
        _title.text = title;
        _info.text = info;
        _title.color = levelColors[(int)skillLevel];
        gameObject.SetActive(true);
    }
}
