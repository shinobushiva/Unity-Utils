 using UnityEngine;
using System.Collections;

public class SwitchableCamera : MonoBehaviour
{
	public Camera c;

	void Awake(){
	}
	
	void Start ()
	{
		if (c == null) {
			c = GetComponentInChildren<Camera>();
		}

	}

	public void On(bool f){
		Behaviour[] mbs = GetComponentsInChildren<Behaviour> ();
		foreach (Behaviour mb in mbs) {
			if(mb == null)
				continue;

			mb.enabled = f;
		}
		//enabled = true;
	}
 

}
