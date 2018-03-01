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
            Instantiate(bullet, transform.position, transform.rotation);
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
