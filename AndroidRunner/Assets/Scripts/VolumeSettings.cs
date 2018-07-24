using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour {

	public Slider slider;

	void Start(){
		slider.value = AudioListener.volume;
	}

	void Update () {
		AudioListener.volume = slider.value;
	}
}
