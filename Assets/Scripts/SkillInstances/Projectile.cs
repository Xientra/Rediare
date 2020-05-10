using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour {

    public abstract void Fire(Entity target, float duration, Action onFinish);
}