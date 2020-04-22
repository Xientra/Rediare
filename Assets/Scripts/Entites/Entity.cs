﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour {

	[Header("References:")]

#pragma warning disable 0649
	/// <summary>
	/// A visual center of the Entity used as a target for projectiles for example.
	/// Returns transform.position if none is assinged.
	/// </summary>
	[Tooltip("A visual center of the Entity used as a target for projectiles for example.")]
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
#pragma warning restore 0649

	[Header("Identification:")]

	[SerializeField]
	private int id;

	[SerializeField]
	private new string name = "[Name]";
	public string Name {
		get => name;
		set {
			name = value;
		}
	}

	/* =:=:=:=:=:=: Base Stats :=:=:=:=:=:=:= */
	[Header("Base Stats:")]

	[SerializeField]
	protected float level = 1;
	public float Level { get => level; set => level = value; }
	public void LevelUp() {
		level++;
	}

	[SerializeField]
	private float experience;
	public float Experience { get => experience; }
	public float AddExp(float amount) {
		experience += amount;
		return experience;
	}
	public void LoseExp(float amount) {
		experience -= amount;
	}

	[SerializeField]
	protected float maxHP = 100;
	public virtual float MaxHP { get => maxHP; }

	[SerializeField]
	protected float health = 100;
	public float Health { get => health; }
	public void DealDamage(float amount) {
		health -= amount;
	}
	public void Heal(float amount) {
		health += amount;
	}

	[SerializeField]
	protected float maxMP = 100;
	public virtual float MaxMP { get => maxMP; }

	[SerializeField]
	protected float magicPoints = 100;
	public float MagicPoints { get => magicPoints; }
	public void UseMP(float amount) {
		magicPoints -= amount;
	}
	public void RestoreMP(float amount) {
		magicPoints += amount;
	}


	/* =:=:=:=:=:=: Combat Stats :=:=:=:=:=:=:= */

	[SerializeField]
	protected float attack = 10;
	public virtual float Attack { get => attack; }

	[SerializeField]
	protected float defence = 10;
	public virtual float Defence { get => defence; }

	[SerializeField]
	protected float evasion = 10;
	public virtual float Evasion { get => evasion; }

	[SerializeField]
	protected float criticalHitChance;
	public virtual float CriticalHitChance { get => criticalHitChance; }

	[SerializeField]
	protected float criticalHitMulipier;
	public virtual float CriticalHitMulipier { get => criticalHitMulipier; }

}