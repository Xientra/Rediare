using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingProjectile : Projectile {

    public GameObject hitEffect;

    private Vector3 startPoint;
    private NPC target;
    private float duration;
    private float time = 0;
    private Action onFinish;

    private bool done = false;

    private void Awake() {
        startPoint = transform.position;
    }

    public override void Fire(NPC target, float duration, Action onFinish) {
        this.target = target;
        this.duration = duration;
        this.onFinish = onFinish;
    }

    void Update() {
        // move
        if (done == false) {
            time += Time.deltaTime;
            transform.position = Vector3.Lerp(startPoint, target.Center, time / duration);
        }

        // on hit
        if (time >= duration && done == false) {
            done = true;
            OnHit();
        }

        // face the target if not hit yet
        if (done == false) {
            transform.forward = (-transform.position + target.Center);
        }
    }

    private void OnHit() {
        onFinish.Invoke();

        // create hit effect
        GameObject temp = Instantiate(hitEffect, target.Center, transform.rotation);
        Destroy(temp, 3f);
        
        // destroy this object
        Destroy(this.gameObject, 3f);
    }
}