using UnityEngine;

public static class GlobalValues {

	private static float EvaluateExpCurve(int i) {
		// x^3 * 5		-=-		aufleitung (5/4) * x^4
		return Mathf.Pow(i, 3f) * 5f;
	}

	public static float GetRequireredExpForNextLevel(int currentLevel) {
		currentLevel++;
		currentLevel = Mathf.Clamp(currentLevel, 0, 100);
		return EvaluateExpCurve(currentLevel);
	}
}
