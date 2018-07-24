using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onEnable : MonoBehaviour {

	void OnEnable()
	{
		FindObjectOfType<AudioManager>().Play("Click");
	}
	void OnDisable(){
		FindObjectOfType<AudioManager>().Play("Click");
	}
}
