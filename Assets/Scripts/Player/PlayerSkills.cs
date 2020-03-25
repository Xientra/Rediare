using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PlayerSkills {

	/// <summary>
	/// The Skills the player learns and gets through level up.
	/// </summary>
	public List<Skill> skills;
	/// <summary>
	/// The Skills the player equipment gives him.
	/// </summary>
	public List<Skill> equipmentSkills;

	/// <summary>
	/// The Skills the player currently has equiped in his action bar.
	/// </summary>
	public Skill[] equipedSkills = new Skill[10];


	public List<Skill> GetAllSkills() {
		List<Skill> allSkills = new List<Skill>();
		allSkills.AddRange(skills);
		allSkills.AddRange(equipmentSkills);
		return allSkills;
	}
}