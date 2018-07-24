using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {


	public static bool GameIsPaused = false;

	public GameObject pauseMenuUI;


	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)){
			if(GameIsPaused){
				Resume();
			}
			else{
				Pause();
			}
		}

	}
	public void Resume(){
		FindObjectOfType<AudioManager>().Play("Click");
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		GameIsPaused = false;
	}
	public void Pause(){
		FindObjectOfType<AudioManager>().Play("Click");
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		GameIsPaused = true;
	}
	public void MenuBack(){
		FindObjectOfType<AudioManager>().Play("Click");
		SceneManager.LoadScene("Menu");
		GameIsPaused = false;
		Time.timeScale = 1f;
		Player.isPlayerAlive = true;
		scoreManager.scoreCount = 0f;
	}

}
