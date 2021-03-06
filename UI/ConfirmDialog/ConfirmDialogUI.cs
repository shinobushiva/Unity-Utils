﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class ConfirmDialogUI : MonoBehaviour
{

	public Text title;
	public Text content;
	public Button approveButton;
	private Text approveButtonText;
	public Button cancelButton;
	private Text cancelButtonText;
	private Action<bool> action;

	public GameObject dialog;

	public void Show (string title, string content, 
		                 string approveText, string cancelText, 
		                 Action<bool> action)
	{
		Setup ();

		this.title.text = title;
		this.content.text = content;
		approveButtonText.text = approveText;
		cancelButtonText.text = cancelText;

		this.action = action;

		dialog.SetActive (true);

	}

	void Setup ()
	{
		if (approveButtonText != null)
			return;
		
		approveButton.onClick.RemoveAllListeners();
		cancelButton.onClick.RemoveAllListeners ();

		approveButtonText = approveButton.GetComponentsInChildren<Text> (true) [0];
		cancelButtonText = cancelButton.GetComponentsInChildren<Text> (true) [0];
			
		approveButton.onClick.AddListener (() => {

			dialog.SetActive (false);
			action (true);
		});
		cancelButton.onClick.AddListener (() => {

			dialog.SetActive (false);
			action (false);
		});
	}

	// Use this for initialization
	void Start ()
	{
		Setup ();
		dialog.SetActive (false);
	}
		
}
