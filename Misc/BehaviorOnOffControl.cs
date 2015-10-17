using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;
using Shiva.UI;

public class BehaviorOnOffControl : MonoBehaviour {

	private List<Behaviour> targets;

	private InputModeIcon inputMode;

	void Awake(){
		inputMode = GameObject.FindObjectOfType<InputModeIcon> ();
		if (inputMode)
			inputMode.SetMode ("mousing");
	}

	// Use this for initialization
	void Start () {
		targets = new List<Behaviour> ();

//		targets.AddRange (GetComponentsInChildren<MouseLook> ());
		targets.AddRange (GetComponentsInChildren<FirstPersonController> ());
		targets.AddRange (GetComponentsInChildren<RigidbodyFirstPersonController> ());

		Cursor.visible = false;
	}

	bool toggle = true;

	// Update is called once per frame
	void Update () {

		bool b  = Input.GetKey (KeyCode.LeftShift);
		if(b != toggle){
			toggle = b;

			foreach (Behaviour ml in targets) {
				ml.enabled = toggle;
			}

			if (toggle) {
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
				if (inputMode)
					inputMode.SetMode ("walking");
			} else {
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
				if (inputMode)
					inputMode.SetMode ("mousing");
			}
		}
		    
	}
}
