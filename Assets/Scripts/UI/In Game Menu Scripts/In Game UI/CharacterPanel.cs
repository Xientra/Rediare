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

	private Player player;

	void Start() {
		player = InGameMenu.instance.player;

		nameLabel.text = player.name;
	}

	void Update() {
		levelLabel.text = player.Level.ToString();
		expBar.MaxValue = GlobalValues.GetRequireredExpForNextLevel(player.Level);
		expBar.CurrentValue = player.Experience;
		hpBar.MaxValue = player.MaxHP;
		hpBar.CurrentValue = player.HealthPoints;
		mpBar.MaxValue = player.MaxMP;
		mpBar.CurrentValue = player.MagicPoints;
	}
}
