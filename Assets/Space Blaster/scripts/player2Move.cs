﻿// FOR TESTING PURPOSES

using UnityEngine;
using System.Collections;

public class player2Move : MonoBehaviour {

	public bool isJumping = false;
	
	float jumpTime, jumpDelay = .5f;
	
	Animator anim;
	 
	void Start()
	{
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		bool cont = true;
		if(cont)  cont = amIAlive();
		if (cont) cont = Movement();
	}
	
	bool amIAlive(){
		player P = GetComponent<player> ();
		bool ret = true;
		if (P.health <= 0 && P.lives <= 0) {
			ret = false;
		}
		return ret;
	}
	
	bool Movement()
	{
		anim.SetFloat("speed", Mathf.Abs(Input.GetAxis ("Horizontal2")));
		
		//	same as GetKey(KeyCode.L)
		if(Input.GetAxisRaw("Horizontal2") > 0)
		{
			transform.Translate(Vector2.right * 6f * Time.deltaTime);
			transform.eulerAngles = new Vector2(0, 0);
		}
		//	same as GetKey(KeyCode.J)
		if(Input.GetAxisRaw("Horizontal2") < 0)
		{
			transform.Translate(Vector2.right * 6f * Time.deltaTime);
			transform.eulerAngles = new Vector2(0, 180);
		}
		if(Input.GetKeyDown(KeyCode.I) && !isJumping)
		{
			GetComponent<Rigidbody2D>().AddForce (Vector2.up * 200f);
			isJumping = true;
			jumpTime = jumpDelay;
			anim.SetBool("jump", true);
			anim.SetBool("land", false);
		}

	
		return true;
	}
	
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Ground")
		{
			isJumping = false;
			anim.SetBool("jump", false);
			anim.SetBool("land", true);
		}
		if (col.gameObject.tag == "Respawn") {
			this.GetComponent<player>().kill();
			Debug.Log("Respawn");
		}
	}
}