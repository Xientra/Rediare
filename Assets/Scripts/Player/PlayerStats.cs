using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[Serializable]
public class PlayerStats {

	public int LVL { get; private set; }
	private int LevelUp() {
		LVL++;
		return LVL;
	}

	public float EXP { get; private set; }
	public float AddEXP(float amount) {
		EXP += amount;
		return EXP;
	}

	public float HP { get; private set; }
	public float ChangeHealth(float amount) {
		HP += amount;
		return HP;
	}

	public float maxHP { get; private set; }
	public void UpdateMaxHP(int newMaxHp) {
		maxHP = newMaxHp;
		HP = maxHP;
	}

	public float MP { get; private set; }
	public float ChangeMP(float amount) {
		MP += amount;
		return MP;
	}

	public float maxMP { get; private set; }
	public void UpdateMaxMP(int newMaxMP) {
		maxMP = newMaxMP;
	}

	public int STR { get; private set; }
	public int DEX { get; private set; }
	public int INT { get; private set; }
	
	public PlayerStats() {
		LVL = 1;
		EXP = 0;
		maxHP = 100f;
		HP = maxHP;
		maxMP = 100f;
		MP = maxMP;
		STR = 5;
		DEX = 5;
		INT = 5;
	}
}