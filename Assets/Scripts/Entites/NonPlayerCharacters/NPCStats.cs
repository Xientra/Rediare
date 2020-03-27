using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class NPCStats {

	[SerializeField]
	private float health = 100;
	public float Health { get => health; }
	public void ChangeHealth(float amount) {
		health += amount;
	}

	[SerializeField]
	private float attack = 10;
	public float Attack { get => attack; }

	[SerializeField]
	private float defence = 10;
	public float Defence { get => defence; }

	[SerializeField]
	private float level = 1;
	public float Level { get => level; }

	[SerializeField]
	private float expDrop = 10;
	public float ExpDrop { get => expDrop; }

}