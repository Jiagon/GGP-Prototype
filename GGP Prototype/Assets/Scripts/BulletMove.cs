﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour {

    public float speed = 4.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 FORWARD = transform.TransformDirection(Vector3.forward);
        // Moves player forward
        transform.localPosition += FORWARD * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
            collision.gameObject.GetComponent<EnemyAI>().HitByBullet();
        Destroy(this.gameObject);
    }
}
