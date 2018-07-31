using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnObst : MonoBehaviour {


	public GameObject obstacles;
	public GameObject flyingObstacles;
	public Transform spawnPoint;
	public Transform spawnPoint2;
	public Transform spawnPoint3;
	public GameObject plant;

	private int obstaclesCount = 1;
	private bool spawnObstacles = true;
	private float spawnRate = 3f;
	private float nextSpawn;
	private float maceFlySpawn;
	private float maceRate = 15f;
	private float plantRate = 28f;
	private float plantSpawn;
	private float jumpToSecCount = 50f;

	void Start ()
	{
		nextSpawn = Time.time + spawnRate; //Spiketime
		maceFlySpawn = Time.time + maceRate; //maceTime
		plantSpawn = Time.time + plantRate;
	}



	void Update ()
	{
			if(spawnPoint != null && spawnPoint2 != null)
				SpawnNextObstacles();

				//Debug.Log("State:" + obstaclesCount);
	}

	private void SpawnNextObstacles()
	{
		if(spawnObstacles)
			SpawningObst1();
	}



	private void SpawningObst1()
	{
		SpikeSpawning();
		MaceSpawning();
		PlantSpawning();
		if(scoreManager.scoreCount >= jumpToSecCount)
			obstaclesCount = 2;
	}


	private void SpikeSpawning()
	{
		if(Time.time > nextSpawn)
		{
			SpikeInst();
		}
	}

	private void PlantSpawning(){
		if(scoreManager.scoreCount >= 30f)
		{
			if(Time.time > plantSpawn)
			{
				PlantInst();
			}
		}
	}

	private void MaceSpawning()
	{
		if(scoreManager.scoreCount >= 10f)
		{
			if(Time.time > maceFlySpawn)
			{
				MaceInst();
			}
		}
	}



	//--- Insts -----
			private void PlantInst()
			{
				GameObject clonePlant = Instantiate(plant,new Vector2(spawnPoint3.position.x,1f),Quaternion.identity) as GameObject;
				Destroy(clonePlant,10f);
				plantSpawn = Time.time + Random.Range(23f,plantRate);
				switch(obstaclesCount)
				{
					case 1: plantSpawn = Time.time + Random.Range(23f,plantRate);
					break;
					case 2: plantSpawn = Time.time + Random.Range(23f, plantRate - 3f);
					break;
				}
			}


			private void MaceInst()
			{
				GameObject cloneFlySpike = Instantiate(flyingObstacles,new Vector2(spawnPoint2.position.x,1.57f),Quaternion.identity) as GameObject;
				Destroy(cloneFlySpike,10f);
				switch(obstaclesCount)
				{
					case 1: maceFlySpawn = Time.time + Random.Range(12f,maceRate);
					break;
					case 2: maceFlySpawn = Time.time + Random.Range(10f,maceRate - 2f);
					break;
				}
			}

			private void SpikeInst()
			{
				GameObject cloneSpike = Instantiate(obstacles,new Vector2(spawnPoint.position.x,-0.94f),Quaternion.identity) as GameObject;
				Destroy(cloneSpike,7f);
				switch(obstaclesCount)
				{
					case 1: nextSpawn = Time.time + Random.Range(1f,spawnRate);
					break;
					case 2: nextSpawn = Time.time + Random.Range(1f,1.8f);
					break;
				}
			}

// ---- Insts ----


}
