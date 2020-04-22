using UnityEngine;
using System;

[Obsolete]
[Serializable]
public class CombatStats {

	[SerializeField]
	private float attack = 10;
	public float Attack { get => attack; }

	[SerializeField]
	private float defence = 10;
	public float Defence { get => defence; }

	[SerializeField]
	private float evasion = 10;
	public float Evasion { get => evasion; }

	[SerializeField]
	protected float criticalHitChance;
	public float CriticalHitChance { get => criticalHitChance; }

	[SerializeField]
	protected float criticalHitMulipier;
	public float CriticalHitMulipier { get => criticalHitMulipier; }
}