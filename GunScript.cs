using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
	public Transform gunPivot;
	public GameObject bullerPrefab;
	public GameObject boxPrefab;
	public Transform bulletSpawn;
	
    void Update()
    {
		//The gun will always point towards the mouse here
		Vector3 mouseScreen = Input.mousePosition;
		Vector3 mouse = Camera.main.ScreenToWorldPoint(mouseScreen);
        gunPivot.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mouse.y - gunPivot.transform.position.y, mouse.x - gunPivot.transform.position.x) * Mathf.Rad2Deg);
		
		//Whenever the player left-clicks, they will shoot a circle. If they right-click, they will shoot a square.
		if(Input.GetKeyDown(KeyCode.Mouse0) && Time.timeScale==1)
		{
			Instantiate(bullerPrefab, bulletSpawn.position, bulletSpawn.rotation);
		}
		if(Input.GetKeyDown(KeyCode.Mouse1) && Time.timeScale==1)
		{
			Instantiate(boxPrefab, bulletSpawn.position, bulletSpawn.rotation);
		}
    }
}
