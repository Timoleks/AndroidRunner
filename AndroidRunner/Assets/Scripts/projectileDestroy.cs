using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileDestroy : MonoBehaviour {

	public GameObject pshit;
	private GameObject player;



	void Start()
	{
		player = GameObject.Find("Character");
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			if(beeFly.beeDamage != 0f){
				player.GetComponent<Player>().TakeDamage(beeFly.beeDamage);
				FindObjectOfType<AudioManager>().Play("BeeHit");
			}
			 // else
				// player.GetComponent<BoxCollider2D>().enabled = false;

			GameObject cloneParticle = Instantiate(pshit,transform.position,Quaternion.identity);
			Destroy(cloneParticle,2f);
			Destroy(gameObject);

		}
	}

}
