using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
	Rigidbody2D rb;
	public float bulletSpeed = 5f;
	public float lifeTime = 5f;
	
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
		rb.AddForce(transform.right * bulletSpeed, ForceMode2D.Impulse);
		Invoke("Despawn",lifeTime);
    }
	
	void Despawn()
	{
		Destroy(gameObject);
	}
}
