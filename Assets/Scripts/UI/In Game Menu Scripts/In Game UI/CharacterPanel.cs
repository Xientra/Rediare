using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterPanel : MonoBehaviour {

	public TextMeshProUGUI nameLabel;
	public TextMeshProUGUI levelLabel;
	public ValueDisplayBar expBar;	
	public ValueDisplayBar hpBar;
	public ValueDisplayBar mpBar;

	private PlayerStats statsToDisplay;

	void Start() {
		Player p = InGameMenu.instance.player;
		statsToDisplay = p.fullStats;

		nameLabel.text = p.name;
	}

	void Update() {
		levelLabel.text = statsToDisplay.Level.ToString();
		//expBar.MaxValue = statsToDisplay.ExperienceNeeded();
		expBar.CurrentValue = statsToDisplay.Experience;
		hpBar.MaxValue = statsToDisplay.MaxHP;
		hpBar.CurrentValue = statsToDisplay.HealthPoints;
		mpBar.MaxValue = statsToDisplay.MaxMP;
		mpBar.CurrentValue = statsToDisplay.MagicPoints;
	}
}
