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
	private float plantRate = 25f;
	private float plantSpawn;

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
		if(scoreManager.scoreCount >= 20f)
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
		if(scoreManager.scoreCount >= 15f)
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
				plantSpawn = Time.time + Random.Range(21f,plantRate);
			}


			private void MaceInst()
			{
				GameObject cloneFlySpike = Instantiate(flyingObstacles,new Vector2(spawnPoint2.position.x,1.57f),Quaternion.identity) as GameObject;
				Destroy(cloneFlySpike,10f);
				maceFlySpawn = Time.time + Random.Range(12f,maceRate);
			}

			private void SpikeInst()
			{
				GameObject cloneSpike = Instantiate(obstacles,new Vector2(spawnPoint.position.x,-0.94f),Quaternion.identity) as GameObject;
				Destroy(cloneSpike,7f);
				switch(obstaclesCount)
				{
					case 1: nextSpawn = Time.time + Random.Range(1f,spawnRate);
					break;
					case 2: nextSpawn = Time.time + Random.Range(1f,2.4f);
					break;
				}
			}

// ---- Insts ----


}
