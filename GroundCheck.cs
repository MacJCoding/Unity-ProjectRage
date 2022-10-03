using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class checks if the player is touching the ground
public class GroundCheck : MonoBehaviour
{
	public bool isOnGround = false;
	
    void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag=="Ground")
		isOnGround = true;
	}
	
	void OnTriggerStay2D(Collider2D col)
	{
		if(col.tag=="Ground")
		isOnGround = true;
	}
	
	void OnTriggerExit2D(Collider2D col)
	{
		if(col.tag=="Ground")
		isOnGround = false;
	}
}
