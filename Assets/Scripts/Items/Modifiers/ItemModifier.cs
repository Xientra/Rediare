using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class ItemModifier {

	[SerializeField]
	private float value;
	public float Value { get => value; }

	public ItemModifier(float value) {
		this.value = value;
	}

	public ItemModifiers.Types type = ItemModifiers.Types.maxHP;

	public enum CalculationMethods { additive, multiplicative, multiplicativePercent }
	public CalculationMethods calculationMethod = CalculationMethods.additive;

	//public Func<float, float, float> calculationMethod = (x, y) => x + y;

	public float Apply(float otherValue) {
		switch (calculationMethod) {
			case CalculationMethods.additive:
				return value + otherValue;
			case CalculationMethods.multiplicative:
				return value * otherValue;
			case CalculationMethods.multiplicativePercent:
				return (value / 100) * otherValue;

			default:
				return value + otherValue;
		}
	}
}