using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blurEffect : MonoBehaviour {


	public float timeBtwSpawns =0f;
	public float startTimeBtwSpawns;

	public GameObject[] echo;
	

	void Start(){

	}

	void Update () {
		if(timeBtwSpawns <=0){
			SpawnRandom();
			timeBtwSpawns = startTimeBtwSpawns;
		}
		else{
			timeBtwSpawns -= Time.deltaTime;

		}
	}

	void SpawnRandom(){
			int random_int = Random.Range(0,echo.Length);
			GameObject	echoClone = Instantiate(echo[random_int],transform.position,Quaternion.identity) as GameObject;
			Destroy(echoClone,0.6f);
	}
}
