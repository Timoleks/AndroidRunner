using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beeFly : MonoBehaviour {

	private GameObject playerFlyPos;
	private GameObject shootPointBee;
	public GameObject projectile;
	public static float beeDamage = 10f;
	public GameObject beeDeathParticles;
	public float deathDelay = 11f;

	private float nextSpawn = 3f;
	private float shootForce = 230f;
	private float speed = 5f;


	void Start(){
		shootPointBee = GameObject.Find("shootPointBee");
		playerFlyPos = GameObject.Find("beePoint");
		StartCoroutine(Death());
	}

	IEnumerator Death(){

		yield return new WaitForSeconds(deathDelay);
		Destroy(gameObject);
		GameObject cloneDeathParticlesBee = Instantiate(beeDeathParticles,transform.position,Quaternion.identity);
		Destroy(cloneDeathParticlesBee,2f);
		FindObjectOfType<AudioManager>().Play("BeeHit");
	}

	void Update () {
		if(playerFlyPos != null){
			transform.position = Vector2.MoveTowards(transform.position,playerFlyPos.transform.position,speed * Time.deltaTime);
			if(Time.time > nextSpawn)
				beeAttack();
		}
	}
	void beeAttack(){
	  GameObject cloneProjectile = 	Instantiate(projectile,shootPointBee.transform.position,Quaternion.identity) as GameObject;
		FindObjectOfType<AudioManager>().Play("Throw");
		cloneProjectile.GetComponent<Rigidbody2D>().AddForce(transform.right * shootForce);
		nextSpawn = Time.time + 3f;
	}
}
