using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingProjectile : Projectile {

    public GameObject hitEffect;
    private Vector3 startPoint;
    private Entity target;
    private float duration;
    private float time = 0;
    [Tooltip("How long the Projectile is stuck in the target after it hit.")]
    public float stuckTime = 0;

    private float trailRetractionTime = 1f;
    
    // will be executed once the projectile hit
    private Action onFinish;

    private bool done = false;

    private void Awake() {
        startPoint = transform.position;
    }

    public override void Fire(Entity target, float duration, Action onFinish) {
        this.target = target;
        this.duration = duration;
        this.onFinish = onFinish;
    }

    void Update() {
        if (target == null) {
            Destroy(this.gameObject);
            return;
        }

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

        // parent projectile to target (so it sticks)
        if (stuckTime != 0)
            transform.SetParent(target.transform);

        // makes the trailRenderer disappear
        
        TrailRenderer trailRenderer = GetComponentInChildren<TrailRenderer>();
        if (trailRenderer == null) {
            StartCoroutine(RetractTrailRenderer(trailRenderer));
            //trailRenderer.time = trailRenderer.time / 2;
            //trailRenderer.transform.SetParent(null, true);
            //Destroy(trailRenderer.gameObject, 2f);
        }
        

        // destroy this object
        Destroy(this.gameObject, stuckTime);
    }

    private IEnumerator RetractTrailRenderer(TrailRenderer tr) {

        float trStartTime = tr.time;

        float t = trailRetractionTime;


        while (t > 0) {
            t -= Time.deltaTime;
            tr.time = trStartTime * (t / duration);
            yield return null;
        }
        tr.time = 0;
    }
}