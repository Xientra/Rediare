﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Entity {

	public string npcName;

	public NPCStats stats;

	[SerializeField]
	private bool isHostile = true;
	public bool IsHostile { get => isHostile; }
	void Start() {

	}

	void Update() {
		
		// DEBUG
		transform.position += transform.forward * Mathf.Sin(Time.time) * sinSpeed * Time.deltaTime;
	}



	/* -== DEBUG ==- */
	[Header("DEBUG:")]
	public float sinSpeed = 2;

}