﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour {

  public scoreManager ScoreManager;
  public GameObject player;
  public GameObject ninjaButton;

  private bool isBlurUsed = false;




  private float cooldown = 5f;
  private float durationEffect = 5f;


  void Update(){
    if(PauseMenu.GameIsPaused){
      ninjaButton.GetComponent<Button>().enabled = false;
    }
    if(PauseMenu.GameIsPaused == false){
      if(!isBlurUsed)
        ninjaButton.GetComponent<Button>().enabled = true;
    }
  }
  public void BlurEffect() {
    player.GetComponent<blurEffect>().enabled = true;
    ninjaButton.GetComponent<Button>().enabled = false;
    isBlurUsed = true;
    ninjaButton.GetComponent<Image>().color = new Color32(255,0,0,255);
    FindObjectOfType<AudioManager>().Play("NinjaSkill");
    StartCoroutine(DurableEffect());
  }
  IEnumerator DurableEffect(){
    AvoidDamage();
    yield return new WaitForSeconds(durationEffect);
    BackDamage();
    player.GetComponent<blurEffect>().enabled = false;
    yield return new WaitForSeconds(cooldown);
    cooldown+= 5f;
    ninjaButton.GetComponent<Image>().color = new Color32(255,255,255,255);
    ninjaButton.GetComponent<Button>().enabled = true;
    isBlurUsed = false;
  }
  void AvoidDamage(){
		Player.damage = 0f;
    beeFly.beeDamage = 0f;
	}
  void BackDamage(){
    Player.damage = 50f;
    beeFly.beeDamage = 10f;
  }

}
