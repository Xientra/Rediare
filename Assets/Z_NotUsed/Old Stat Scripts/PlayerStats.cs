using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[Obsolete]
[Serializable]
public class PlayerStats : ModifiableStats {

	[SerializeField]
	private int level;
	public int Level { get => level; }
	public int LevelUp() {
		level++;
		return level;
	}

	[SerializeField]
	private float experience;
	public float Experience { get => experience; }
	public float AddExp(float amount) {
		experience += amount;
		return experience;
	}


	[SerializeField]
	private float healthPoints;
	public float HealthPoints { get => healthPoints; }
	public float ChangeHealth(float amount) {
		healthPoints += amount;
		return healthPoints;
	}

	[SerializeField]
	private float magicPoints;
	public float MagicPoints { get => magicPoints; }
	public float ChangeMP(float amount) {
		magicPoints += amount;
		return magicPoints;
	}


	private PlayerStats() : base() {

		level = 0;
		experience = 0;
		healthPoints = 0;
		magicPoints = 0;
		strength = 0;
		dexterity = 0;
		intelligence = 0;
	}

	private PlayerStats(int level, float experience, float maxHP, float maxMP, int strength, int dexterity, int intelligence,
		 float attack, float defence, float hpRecovery, float criticalHitChance, float criticalHitMulipier, int inventorySize)
		//: base(maxHP, maxMP, attack, defence, hpRecovery, criticalHitChance, criticalHitMulipier, inventorySize) {
		{

		this.level = level;
		this.experience = experience;

		this.strength = strength;
		this.dexterity = dexterity;
		this.intelligence = intelligence;

		this.maxHP = maxHP;
		this.maxMP = maxMP;
		healthPoints = maxHP;
		magicPoints = maxMP;

		this.attack = attack;
		this.defence = defence;
		this.hpRecovery = hpRecovery;
		this.criticalHitChance = criticalHitChance;
		this.criticalHitMulipier = criticalHitMulipier;
		this.inventorySize = inventorySize;
	}

	/// <summary>
	/// Returns a PlayerStats Object with the default starting values.
	/// </summary>
	public static PlayerStats Default {

		get {
			int level = 1;
			float experience = 0;
			float maxHP = 100f;
			float maxMP = 100f;
			int strength = 5;
			int dexterity = 5;
			int intelligence = 5;

			float attack = 10;
			float defence = 0;
			float hpRecovery = 0.01f;
			float criticalHitChance = 0.1f;
			float criticalHitMulipier = 1.5f;
			int inventorySize = 10;

			return new PlayerStats(level, experience, maxHP, maxMP, strength, dexterity, intelligence, attack, defence, hpRecovery, criticalHitChance, criticalHitMulipier, inventorySize);
		}
	}


	/// <summary>
	/// Sets the stats to the combination of the players baseStats and the additional stats given by the equipment (itemStats).
	/// </summary>
	public void UpdateFullStats(PlayerStats baseStats, ModifiableStats itemStats) {

		level = baseStats.Level;
		experience = baseStats.Experience;
		healthPoints = baseStats.HealthPoints;
		magicPoints = baseStats.MagicPoints;

		maxHP = baseStats.MaxHP + itemStats.MaxHP;
		maxMP = baseStats.MaxMP + itemStats.MaxMP;
		strength = baseStats.Strength + itemStats.Strength;
		dexterity = baseStats.Dexterity + itemStats.Dexterity;
		intelligence = baseStats.Intelligence + itemStats.Intelligence;

		attack = baseStats.Attack + itemStats.Attack;
		defence = baseStats.Defence + itemStats.Attack;
		hpRecovery = baseStats.HPRecovery + itemStats.HPRecovery;
		criticalHitChance = baseStats.CriticalHitChance + itemStats.CriticalHitChance;
		criticalHitMulipier = baseStats.CriticalHitMulipier + itemStats.CriticalHitMulipier;
		inventorySize = baseStats.InventorySize + itemStats.InventorySize;

	}

	/// <summary>
	/// Combines the players base stats and the additional stats given by the equipment and returns it as a new PlayerStats object.
	/// </summary>
	public static PlayerStats CalculateFullStats(PlayerStats baseStats, ModifiableStats itemStats) {

		PlayerStats ps = new PlayerStats();
		ps.UpdateFullStats(baseStats, itemStats);
		return ps;
		/*
		int level = baseStats.Level;
		float experience = baseStats.Experience;
		float maxHP = baseStats.MaxHP + itemStats.MaxHP;
		float maxMP = baseStats.MaxMP + itemStats.MaxMP;
		int strength = baseStats.Strength;
		int dexterity = baseStats.Dexterity;
		int intelligence = baseStats.Intelligence;

		float attack = baseStats.Attack + itemStats.Attack;
		float defence = baseStats.Defence + itemStats.Attack;
		float hpRecovery = baseStats.HPRecovery + itemStats.HPRecovery;
		float criticalHitChance = baseStats.CriticalHitChance + itemStats.CriticalHitChance;
		float criticalHitMulipier = baseStats.CriticalHitMulipier + itemStats.CriticalHitMulipier;
		int inventorySize = baseStats.InventorySize + itemStats.InventorySize;

		return new PlayerStats(level, experience, maxHP, maxMP, strength, dexterity, intelligence, attack, defence, hpRecovery, criticalHitChance, criticalHitMulipier, inventorySize);
		*/
	}
}