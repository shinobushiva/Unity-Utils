using UnityEngine;
using System.Collections;

public class NetworkPosition : MonoBehaviour {

	public Vector3 myPosition;
	public Vector3 myScale;
	public Quaternion myRotate;
	// Use this for initialization
	void Start () {
        
		myPosition = gameObject.transform.position;
		myRotate = gameObject.transform.rotation;
		myScale = gameObject.transform.localScale;
	}


	// Update is called once per frame
	void Update () {
        

    }
}
