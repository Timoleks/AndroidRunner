using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryPanel : MonoBehaviour {


 public GameObject retryPanel;

	void Update () {
		if(!Player.isPlayerAlive)
			PauseR();

	}
	public void PauseR(){

		retryPanel.SetActive(true);
		Time.timeScale = 0f;

	}
	public void Retry(){
		SceneManager.LoadScene("Scene01");
		retryPanel.SetActive(false);
		Player.isPlayerAlive = true;
		Time.timeScale = 1f;
	}
}
