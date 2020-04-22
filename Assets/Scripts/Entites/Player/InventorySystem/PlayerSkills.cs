using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PlayerSkills {

	/// <summary>
	/// The Skills the player learns and gets through level up.
	/// </summary>
	public List<Skill> naturalSkills;
	/// <summary>
	/// The Skills the player equipment gives him.
	/// </summary>
	public List<Skill> equipmentSkills;


	public List<Skill> GetAllSkills() {
		List<Skill> allSkills = new List<Skill>();
		allSkills.AddRange(naturalSkills);
		allSkills.AddRange(equipmentSkills);
		return allSkills;
	}
}