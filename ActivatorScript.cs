using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorScript : MonoBehaviour
{
	public List<GameObject> objectsToUnlock = new List<GameObject>();
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag=="Bullet")
		{
			Unlock();
		}
	}
	
	public void Unlock()
	{
		foreach(GameObject g in objectsToUnlock)
		{
			g.SetActive(false);
		}
		Destroy(gameObject);
	}
}
