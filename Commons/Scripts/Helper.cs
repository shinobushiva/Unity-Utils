using UnityEngine;
using System.Collections;

public static class Helper
{

	public static Bounds GetBoundingBox (GameObject go, bool rotationVariant = false)
	{

		Quaternion rot;
		if (rotationVariant) {
			rot = go.transform.rotation;
			go.transform.rotation = Quaternion.identity;
		}

		Renderer[] rs = go.GetComponentsInChildren<Renderer> ();
		if (rs.Length <= 0) {
			return new Bounds ();
		}

		Bounds b = GetBounds (rs [0]);
		for (int i = 1; i < rs.Length; i++) {
			b.Encapsulate (GetBounds (rs [i]));
		}

		return b;
	}

	public static void SetLayerRecursively (this GameObject obj, int layer)
	{
		obj.layer = layer;
		
		foreach (Transform child in obj.transform) {
			child.gameObject.SetLayerRecursively (layer);
		}
	}

	public static Bounds GetBounds (Renderer r)
	{
		
		if (r is SkinnedMeshRenderer) {
			SkinnedMeshRenderer smr = r as SkinnedMeshRenderer;
			Mesh mesh = smr.sharedMesh;

			Vector3[] vertices = mesh.vertices;
			if (vertices.Length <= 0) {
				return r.bounds;
			}
			int idx = 0;
			Vector3 min, max;
			min = max = r.transform.TransformPoint (vertices [idx++]);

			for (int i = idx; i < vertices.Length; i++) {
				Vector3 v = vertices [i];
				Vector3 V = r.transform.TransformPoint (v);
				for (int n = 0; n < 3; n++) {
					if (V [n] > max [n])
						max [n] = V [n];
					if (V [n] < min [n])
						min [n] = V [n];
				}
			}

			Bounds b = new Bounds ();;
			b.SetMinMax (min, max);
			return b;

		} else {
			return r.bounds;
		}
	}

}
