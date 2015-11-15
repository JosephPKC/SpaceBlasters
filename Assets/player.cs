﻿using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	
	public int health = 3;
	public int playerNumber = 1;
	public Transform shooter;
	
	// Use this for initialization
	void OnTriggerEnter2D(Collider2D col) {
		projectileDamage P = col.GetComponent<projectileDamage> ();
		// prevent player from shooting self
		// yields NullReferenceError when col is a powerup/weapon
		if (P != null && P.shooter != this.transform) {
			// prevents collision with powerup/weapon from doing damage
			// incomplete method... think of something more efficient
			if (col.transform.name == "red photon(Clone)")
			{
				health--;
			}
		}
	}

	public void kill(){
		health = 0;
		die();
	}
	// Update is called once per frame
	void Update () 
	{
		if (health <= 0)
		{
			die();
		}
	}
	
	void die()
	{
		Destroy (gameObject);
	}
}
