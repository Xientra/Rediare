using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatsWindow : MonoBehaviour {

	PlayerStats playerStats;


	public TextMeshProUGUI healthPointsLabel;
	private string healthPointsText;
	public TextMeshProUGUI magicPointsLabel;
	private string magicPointsText;
	public TextMeshProUGUI strengthLabel;
	private string strengthText;
	public TextMeshProUGUI dexterityLabel;
	private string dexterityText;
	public TextMeshProUGUI intelligenceLabel;
	private string intelligenceText;
	public TextMeshProUGUI attackLabel;
	private string attackText;
	public TextMeshProUGUI defenceLabel;
	private string defenceText;
	public TextMeshProUGUI criticalHitChanceLabel;
	private string criticalHitChanceText;
	public TextMeshProUGUI criticalHitMulipierLabel;
	private string criticalHitMulipierText;
	public TextMeshProUGUI hpRecoveryLabel;
	private string hpRecoveryText;


	void Start() {
		playerStats = InGameMenu.instance.player.fullStats;


		healthPointsText = healthPointsLabel.text;
		magicPointsText = magicPointsLabel.text;
		strengthText = strengthLabel.text;
		dexterityText = dexterityLabel.text;
		intelligenceText = intelligenceLabel.text;
		attackText = attackLabel.text;
		defenceText = defenceLabel.text;
		criticalHitChanceText = criticalHitChanceLabel.text;
		criticalHitMulipierText = criticalHitMulipierLabel.text;
		hpRecoveryText = hpRecoveryLabel.text;

		UpdateUI();
	}

	private void OnEnable() {
		UpdateUI();
	}

	public void UpdateUI() {

		Debug.Log("Stats updated.");

		healthPointsLabel.text = healthPointsText + playerStats.HealthPoints + "/" + playerStats.MaxHP;

		magicPointsLabel.text = magicPointsText + playerStats.MagicPoints + "/" + playerStats.MaxMP;
		strengthLabel.text = strengthText + playerStats.Strength;
		dexterityLabel.text = dexterityText + playerStats.Dexterity;
		intelligenceLabel.text = intelligenceText + playerStats.Intelligence;
		attackLabel.text = attackText + playerStats.Attack;
		defenceLabel.text = defenceText + playerStats.Defence;
		criticalHitChanceLabel.text = criticalHitChanceText + playerStats.CriticalHitChance;
		criticalHitMulipierLabel.text = criticalHitMulipierText + playerStats.CriticalHitMulipier;
		hpRecoveryLabel.text = hpRecoveryText + playerStats.HPRecovery;
	}
}