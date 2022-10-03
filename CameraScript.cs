using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
	public float speed = 10f;
	//The vector is double to dimensions of the camera in units
	public Vector2 cameraMoveInterval = new Vector2(17.7f,10f);
	public Vector2 playerLocation = new Vector2(0f,0f);
	public Transform player;

    void Update()
    {
		//The camera will move corresponding to where the player is
		if(player.position.x > (cameraMoveInterval.x*playerLocation.x) + (cameraMoveInterval.x/2f) && Time.timeScale == 1)
		{
			playerLocation = new Vector2(playerLocation.x+1, playerLocation.y);
			Time.timeScale = 0f;
		}
		if(player.position.x < (cameraMoveInterval.x*playerLocation.x) - (cameraMoveInterval.x/2f) && Time.timeScale == 1)
		{
			playerLocation = new Vector2(playerLocation.x-1, playerLocation.y);
			Time.timeScale = 0f;
		}
		if(player.position.y > (cameraMoveInterval.y*playerLocation.y) + (cameraMoveInterval.y/2f) && Time.timeScale == 1)
		{
			playerLocation = new Vector2(playerLocation.x, playerLocation.y+1);
			Time.timeScale = 0f;
		}
		if(player.position.y < (cameraMoveInterval.y*playerLocation.y) - (cameraMoveInterval.y/2f) && Time.timeScale == 1)
		{
			playerLocation = new Vector2(playerLocation.x, playerLocation.y-1);
			Time.timeScale = 0f;
		}
		
		//Using the Lerp method, the camera will smooth transition from one screen to the next
		transform.position = Vector3.Lerp(transform.position, new Vector3(cameraMoveInterval.x*playerLocation.x, cameraMoveInterval.y*playerLocation.y,-10f),0.01f * speed);
		
		//Time will start again after the camera stop moving
		if(Vector3.Distance(transform.position,new Vector3(cameraMoveInterval.x*playerLocation.x, cameraMoveInterval.y*playerLocation.y,-10f)) < 0.01f)
		{
			Time.timeScale = 1f;
		}
    }
}
