using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameKit.Manager;


public class InputListener : MonoBehaviour {
    

	// Use this for initialization
	void Start () {
        DataManager.s_Instance.onMoneyCountChanged += OnMoneyCountChanged_EventHandler;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.T)) {
            DataManager.s_Instance.AddMoney(5);
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            DataManager.s_Instance.RemoveMoney(1);
        }
	}


    void OnMoneyCountChanged_EventHandler(int newValue) {
        Debug.Log("OnMoneyCountChanged_EventHandler newValue: " + newValue);

    }



    void OnGUI() {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(10, h - 50, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 2 / 50;
        style.normal.textColor = new Color(255.0f, 255.0f, 255.0f, 1.0f);
       
        string text = string.Format("<T> to Add, <R> to Remove");
        GUI.Label(rect, text, style);
    }
}

