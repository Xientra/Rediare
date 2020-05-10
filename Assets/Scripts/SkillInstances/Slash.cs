using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour {


	public GameObject effect;
	private float time = 0;

	private bool fireing = false;
	private bool hit = false;

	private Entity origin;
	private Entity target;
	private float range;
	// the skill will stay active for a while to check if the range of the slash is met later in the attack 
	private float lingeringDuration;
	private Action onFinish;

	public void Fire(Entity origin, Entity target, float range, float lingeringDuration, Action onFinish) {
		this.origin = origin;
		this.target = target;
		this.range = range;
		this.lingeringDuration = lingeringDuration;
		this.onFinish = onFinish;

		fireing = true;

		// activates the child object with the visual on it
		//effect.transform.localPosition = this.transform.forward; //* (range * 0.75f);
		effect.transform.Translate(new Vector3(0, 0, range * 0.75f), this.transform);
		effect.transform.localRotation = Quaternion.Euler(effect.transform.localRotation.x, effect.transform.localRotation.y, UnityEngine.Random.Range(0, 360)); ;
		effect.SetActive(true);
		Destroy(this.gameObject, lingeringDuration + 1);
	}

	private void Awake() {
		effect.SetActive(false);
	}

	private void FixedUpdate() {
		if (fireing == true && time < lingeringDuration) {

			if (hit == false && (origin.transform.position - target.transform.position).magnitude <= range) {
				onFinish.Invoke();
				hit = true;
			}
			time += Time.fixedDeltaTime;
		}
	}
}
