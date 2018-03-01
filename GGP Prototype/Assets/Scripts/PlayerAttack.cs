using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour {

    public Canvas canvas;
    public Text text;
    public GameObject bullet;

    float health;

	// Use this for initialization
	void Start () {
        health = 100;
        canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 FORWARD = transform.TransformDirection(Vector3.forward);
            Vector3 spawnPosition = transform.localPosition + FORWARD * 2;
            Instantiate(bullet, spawnPosition, transform.rotation);
        }
		if(health <= 0)
        {
            text.text = "Game Over!";
        }
        else
        {
            text.text = "Health: " + health;
        }
	}
}