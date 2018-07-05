using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnObst : MonoBehaviour {


	public GameObject obstacles;
	public GameObject flyingObstacles;
	public scoreManager ScoreManager;
	public Transform spawnPoint;
	public Transform spawnPoint2;


	private int obstaclesCount = 1;
	private bool spawnObstacles = true;
	private float spawnRate = 2f;
	private float nextSpawn;
	//private float nextSpawnStage2;
	private float maceFlySpawn;
	private float maceRate = 15f;

	//bool maceSpawn = false;
	void Start () {
		nextSpawn = Time.time + spawnRate; //Spiketime
		maceFlySpawn = Time.time + maceRate; //maceTime
		//nextSpawnStage2 = Time.time + spawnRate;
	}


	// Core Functions -----
	void Update () {
			SpawnNextObstacles();
	}
	 	private void StartObst1(){

		SpikeSpawningObst1();

		//if(ScoreManager.scoreCount >= 40f)
		//	obstaclesCount = 2;
	}
	private void StartObst2(){
		SpikeSpawningObst2();
	}
	private void SpawnNextObstacles(){
		if(spawnObstacles){
			switch(obstaclesCount){
				case 1: StartObst1();  //first stage
				break;
				case 2: StartObst2();
				break;
			}
		}
	}

	// - -------------------------------
	private void SpikeSpawningObst2(){
		if(Time.time > nextSpawn){
			GameObject cloneSpike = Instantiate(obstacles,new Vector2(spawnPoint.position.x,-0.17f),Quaternion.identity) as GameObject;
			Destroy(cloneSpike,6f);
			nextSpawn = Time.time + Random.Range(1f,2f);
    }
	}

	private void SpikeSpawningObst1(){
		if(Time.time > nextSpawn){
			GameObject cloneSpike = Instantiate(obstacles,new Vector2(spawnPoint.position.x,-0.17f),Quaternion.identity) as GameObject;
			Destroy(cloneSpike,7f);
			if(ScoreManager.scoreCount >= 10f)
			{
				//Mace Spawn
				if(Time.time > maceFlySpawn){
					MaceFly();
				}
			}
			nextSpawn = Time.time + Random.Range(1f,3f);
    }
	}
	private void MaceFly(){
		GameObject cloneFlySpike = Instantiate(flyingObstacles,new Vector2(spawnPoint2.position.x,2.42f),Quaternion.identity) as GameObject;
		Destroy(cloneFlySpike,10f);
		maceFlySpawn = Time.time + maceRate;
	}
}
