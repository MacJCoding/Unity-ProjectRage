using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	Rigidbody2D rb;
	public float speed = 5f;
	public float maxSpeed = 1f;
	public float jumpBoost = 5f;
	public GroundCheck groundCheck;
	
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
		//As long as time isn't frozen the player can press A,S,W or their respective arrow keys to move around
		if(Time.timeScale != 0)
		{
			if((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && rb.velocity.x > -maxSpeed)
			{
				rb.AddForce(-transform.right * speed, ForceMode2D.Impulse);
			}
			
			if((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && groundCheck.isOnGround)
			{
				rb.AddForce(transform.up * jumpBoost, ForceMode2D.Impulse);
			}
			
			if((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && rb.velocity.x < maxSpeed)
			{
				rb.AddForce(transform.right * speed, ForceMode2D.Impulse);
			}
			
			//Whenever a left or right key is released the x-velocity is set to zero to stop a "swaying" movement
			if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
			{
				rb.velocity = new Vector2(0f, rb.velocity.y);
			}
		}
    }
}
