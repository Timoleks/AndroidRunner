using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class scoreManager : MonoBehaviour {

	public Text scoreText;
	public Text highScoreText;

	public float scoreCount;
	public float highScoreCount;

	public float pointsPerSec;

	public bool scoreIncreasing;
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if(scoreIncreasing)
			scoreCount+=pointsPerSec * Time.deltaTime;
		
		if(scoreCount > highScoreCount){
			highScoreCount = scoreCount;
		}


		scoreText.text = "YourScore: " + Mathf.Round(scoreCount);
		highScoreText.text = "HighScore: " + Mathf.Round(highScoreCount);

	}
}
