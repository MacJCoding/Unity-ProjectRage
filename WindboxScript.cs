using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindboxScript : MonoBehaviour
{
    public bool affectPlayer = true;
	public bool affectBullet = true;
	public float strength = 5f;
	//A list of objects that needs to be "blown" by the windbox
	public List<GameObject> objects = new List<GameObject>();
	public float windPushCooldown = 0.1f;
	bool onCoolDown = false;
	
	void Update()
	{
		//Whenever time is moving and the windbox is not on cooldown push all objects in the list
		if(!onCoolDown && Time.timeScale == 1)
		{
			foreach(GameObject g in objects)
			{
				if(g.GetComponent<Rigidbody2D>() != null)
				{
					g.GetComponent<Rigidbody2D>().AddForce(transform.right * strength, ForceMode2D.Impulse);
				}
			}
			onCoolDown = true;
			Invoke("ResetCooldown", windPushCooldown);
		}
	}
	
	void ResetCooldown()
	{
		onCoolDown = false;
	}
	
	//Checks if an object is in the list
	public bool IsNotInList(GameObject obj)
	{
		bool isPresent = false;
		foreach(GameObject g in objects)
		{
			if(obj==g)
			{
				isPresent = true;
			}
		}
		return !isPresent;
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if(IsNotInList(col.gameObject))
		{
			objects.Add(col.gameObject);
		}
	}
	
	void OnTriggerStay2D(Collider2D col)
	{
		if(IsNotInList(col.gameObject))
		{
			objects.Add(col.gameObject);
		}
	}
	
	void OnTriggerExit2D(Collider2D col)
	{
		if(!IsNotInList(col.gameObject))
		{
			objects.Remove(col.gameObject);
		}
	}
	
	
}
