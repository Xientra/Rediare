using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class EquipmentStatBonuses {

	[SerializeField]
	protected float maxHP;
	public virtual float MaxHP { get => maxHP; }

	[SerializeField]
	protected float maxMP;
	public virtual float MaxMP { get => maxMP; }


	[SerializeField]
	protected int strength;
	public int Strength { get => strength; }

	[SerializeField]
	protected int dexterity;
	public int Dexterity { get => dexterity; }

	[SerializeField]
	protected int intelligence;
	public int Intelligence { get => intelligence; }


	[SerializeField]
	protected float attack;
	public float Attack { get => attack; }

	[SerializeField]
	protected float defence;
	public float Defence { get => defence; }

	[SerializeField]
	private float evasion = 10;
	public float Evasion { get => evasion; }


	[SerializeField]
	protected float healthRecovery;
	public float HealthRecovery { get => healthRecovery; }

	[SerializeField]
	protected float magicRecovery;
	public float MagicRecovery { get => magicRecovery; }


	[SerializeField]
	protected float criticalHitChance;
	public float CriticalHitChance { get => criticalHitChance; }

	[SerializeField]
	protected float criticalHitMulipier;
	public float CriticalHitMulipier { get => criticalHitMulipier; }

}