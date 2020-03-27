using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {

	/// <summary>
	/// A visual center of the Entity used as a target for projectiles for example.
	/// Returns transform.position if none is assinged.
	/// </summary>
	[SerializeField]
	private Transform center;
	/// <summary>
	/// A visual center of the Entity used as a target for projectiles for example.
	/// Returns transform.position if none is assinged.
	/// </summary>
	public Vector3 Center {
		get {
			if (center != null)
				return center.position;

			Debug.LogWarning("The entity " + name + " has no center assinged.");
			return transform.position;
		}
	}
}
