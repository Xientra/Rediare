using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Entity {

	[Header("NPC Stats:")]

	[SerializeField]
	private bool isHostile = true;
	public bool IsHostile { get => isHostile; }

	private Collider col;
	private MeshRenderer meshRenderer;

	public override void GainExp(float amount) {
		Debug.LogWarning("NPCs cannot gain exp! On: " + gameObject.name + " name: " + name);
	}

	[Header("Enemy References:")]
	public GameObject deathEffect;

	void Start() {
		col = GetComponent<Collider>();
		meshRenderer = GetComponentInChildren<MeshRenderer>();
	}

	void Update() {
		
		// DEBUG
		if (healthPoints > 0) transform.position += transform.forward * Mathf.Sin(Time.time) * sinSpeed * Time.deltaTime;
	}

	public override void OnDeath(Entity killer) {

		// give exp to killer
		killer.GainExp(experience);

		// play death animation
		col.enabled = false;
		GameObject temp = Instantiate(deathEffect, Center, transform.rotation);
		Destroy(temp, 4);
		meshRenderer.enabled = false;

		// spawn loot

		// destroy self
		Destroy(this.gameObject);
	}

	/* -== DEBUG ==- */
	[Header("DEBUG:")]
	public float sinSpeed = 2;
}
