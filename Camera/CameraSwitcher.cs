using UnityEngine;
using System.Collections;

public class CameraSwitcher :  SingletonMonoBehaviour<CameraSwitcher>
{
	
	public SwitchableCamera[] cameras;
	public SwitchableCamera currentActive;

	public float seaLevelOffset = 1.762281f;

	// Use this for initialization
	void Start ()
	{
		foreach (SwitchableCamera sc in cameras) {
				sc.On(false);
		}
		cameras [0].On (true);
		currentActive = cameras [0];

		StartCoroutine (UpdateHeight());
	}

	IEnumerator UpdateHeight(){
		while (true) {
			if (currentActive && currentActive.c) {
				float h = currentActive.c.transform.position.y - seaLevelOffset;
				h = ((int)(h * 100)) / 100f;
				if (InfoUI.Instance)
					InfoUI.Instance.SetHeight (h);
			}
			yield return new WaitForSeconds(0.1f);
		}
	}

	void Update(){
	
	}
	
	public void Switch (SwitchableCamera c)
	{ 
		print ("Switch:" + c.gameObject);
		currentActive = c;

		foreach (SwitchableCamera sc in cameras) {
			if(sc == c){
				sc.On(true);
			}else{
				sc.On(false);
			}
		}

	}
}
