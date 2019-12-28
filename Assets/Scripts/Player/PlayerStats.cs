using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[Serializable]
public class PlayerStats {

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
	private float maxHP;
	public float MaxHP { get => maxHP; }
	public void UpdateMaxHP(int newMaxHp) {
		maxHP = newMaxHp;
		hp = maxHP;
	}

	[SerializeField]
	private float mp;
	public float MP { get => mp; }
	public float ChangeMP(float amount) {
		mp += amount;
		return mp;
	}

	[SerializeField]
	private float maxMP;
	public float MaxMP { get => maxMP; }
	public void UpdateMaxMP(int newMaxMp) {
		maxMP = newMaxMp;
		mp = maxMP;
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


	public PlayerStats() {
		lvl = 1;
		exp = 0;
		maxHP = 100f;
		hp = maxHP;
		maxMP = 100f;
		mp = maxMP;
		str = 5;
		dex = 5;
		Int = 5;
	}
}