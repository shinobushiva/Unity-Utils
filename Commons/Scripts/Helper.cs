using UnityEngine;
using System.Collections;

public static class Helper  {

	public static Bounds GetBoundingBox(GameObject go){
		Renderer[] rs = go.GetComponentsInChildren<Renderer> ();
		if (rs.Length <= 0) {
			return new Bounds();
		}

		Bounds b = new Bounds (rs [0].bounds.center, rs [0].bounds.size);
		for(int i=1; i<rs.Length;i++){
			b.Encapsulate(rs[i].bounds);
		}


		return b;
	}

	public static void SetLayerRecursively(this GameObject obj, int layer) {
		obj.layer = layer;
		
		foreach (Transform child in obj.transform) {
			child.gameObject.SetLayerRecursively(layer);
		}
	}
}
