using System;
using System.Collections;
using System.Collections.Generic;

public class InGameMenuEventSystem {

	public static event Action<ItemSlot> OnItemChanged;
	public static void ItemChanged(ItemSlot origin) {
		if (OnItemChanged != null)
			OnItemChanged(origin);
	}

	public static event Action OnStatsChanged;
	public static void StatsChanged() {
		if (OnStatsChanged != null)
			OnStatsChanged();
	}

	public static event Action OnSkillsChanged;
	public static void SkillsChanged() {
		OnSkillsChanged?.Invoke();
	}

	public static event Action<int> OnActionBarChanged;
	public static void ActionBarChanged(int i) {
		OnActionBarChanged?.Invoke(i);
	}
}