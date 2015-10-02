using UnityEngine;
using System.Collections;

public class Helper  {

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
}
