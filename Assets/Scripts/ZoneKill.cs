using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneKill : MonoBehaviour
{
	void Update()
	{

	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "SpaceMan")
		{
			collision.gameObject.GetComponent<PlayerController>().die();
		}
	}
}
