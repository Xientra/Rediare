using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

[System.Serializable]
public class ActionBarSlot {

	public const float UPDATE_INTERVAL = 0.05f;

	private Skill usable;
	public Skill Usable {
		get => usable;
		set {
			usable = value;
		}
	}
	private float cooldown;

	private readonly Timer timer;

	public ActionBarSlot() {
		timer = new Timer();
		timer.Elapsed += new ElapsedEventHandler(Cooldown);
		timer.Interval = UPDATE_INTERVAL * 1000;
	}

	public bool Use(Player origin, NPC target) {
		if (cooldown == 0) {
			usable.Activate(origin, target);
			cooldown = usable.cooldown;
			timer.Start();
			return true;
		}
		else return false;
	}

	private void Cooldown(object sender, ElapsedEventArgs e) {
		if (cooldown > 0) {
			cooldown -= UPDATE_INTERVAL;
		}
		else {
			cooldown = 0;
			timer.Stop();
		}
	}
}