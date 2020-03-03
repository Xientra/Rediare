using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[Serializable]
public class PlayerStats : Stats{

	[SerializeField]
	private int lvl;
	public int LVL { get => lvl; }
	public int LevelUp() {
		lvl++;
		return lvl;
	}

	[SerializeField]
	private float exp;
	public float EXP { get => exp; }
	public float AddExp(float amount) {
		exp += amount;
		return exp;
	}

	[SerializeField]
	private float hp;
	public float HP { get => hp; }
	public float ChangeHealth(float amount) {
		hp += amount;
		return hp;
	}



	[SerializeField]
	private float mp;
	public float MP { get => mp; }
	public float ChangeMP(float amount) {
		mp += amount;
		return mp;
	}



	[SerializeField]
	private int str;
	public int STR { get => str; }

	[SerializeField]
	private int dex;
	public int DEX { get => dex; }

	[SerializeField]
	private int Int;
	public int INT { get => Int; }



	// ----------------------------------------------------------------- the maxHp here might ignore the ones forom items, maybe
	public override void UpdateMaxHP(int newMaxHp) {
		maxHP = newMaxHp;
		hp = maxHP;
	}

	public override void UpdateMaxMP(int newMaxMp) {
		maxMP = newMaxMp;
		mp = maxMP;
	}


	public PlayerStats() : base() {

		maxHP = 100f;
		maxMP = 100f;

		attack = 10;
		defence = 0;
		hpRecovery = 0.01f;
		criticalHitChance = 0.1f;
		criticalHitMulipier = 1.5f;
		inventorySize = 10;

		lvl = 1;
		exp = 0;
		hp = maxHP;
		mp = maxMP;
		str = 5;
		dex = 5;
		Int = 5;
	}
}