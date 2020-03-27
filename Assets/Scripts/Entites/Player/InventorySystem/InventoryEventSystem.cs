using System;
using System.Collections;
using System.Collections.Generic;

public class InventoryEventSystem {

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
}