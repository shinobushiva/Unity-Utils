﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ApproveCancelSetup : MonoBehaviour {

    public Toggle toggle;

	// Use this for initialization
	void Start () {

        ApproveCancelUI ui = GetComponent<ApproveCancelUI>();
        ui.Set("スタート画面に戻りますか？", "はい", "いいえ", 
        () => {
            Application.LoadLevel("Start");
        },
        () => {
            gameObject.GetComponent<Canvas>().enabled = false;
            gameObject.SetActive(false);
            toggle.isOn = false;
        });
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}