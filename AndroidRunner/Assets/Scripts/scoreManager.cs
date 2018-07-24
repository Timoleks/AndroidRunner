using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class scoreManager : MonoBehaviour {

	public Text scoreText;
	public Text highScoreText;

	public static float scoreCount;
	public static float highScoreCount;

	public float pointsPerSec;

	public bool scoreIncreasing;
	void Start () {
		highScoreText.text = "HighScore: " + PlayerPrefs.GetFloat("HighScore", 0f);
	}

	// Update is called once per frame
	void Update () {
		if(scoreIncreasing)
			scoreCount+=pointsPerSec * Time.deltaTime;

		scoreText.text = "YourScore: " + Mathf.Round(scoreCount);

		if(!Player.isPlayerAlive){
			scoreIncreasing = false;
		}
	}


}
