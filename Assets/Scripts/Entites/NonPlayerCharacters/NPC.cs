using System.Collections;
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

	}
}
