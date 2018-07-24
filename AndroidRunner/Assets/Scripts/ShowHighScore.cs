using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHighScore : MonoBehaviour {

	public Text highScoreText;

	void Start () {
		highScoreText.text = PlayerPrefs.GetFloat("HighScore", scoreManager.highScoreCount).ToString();
	}

	// Update is called once per frame
	void Update () {

	}

	public void ResetScore(){
		PlayerPrefs.DeleteKey("HighScore");
		highScoreText.text = "0";
		FindObjectOfType<AudioManager>().Play("Click");
	}
}
