using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowTo : MonoBehaviour {

	public GameObject howToPanel;

	public void HowToPanel(){
		howToPanel.SetActive(true);
	}
	public void ClosePanel(){
		howToPanel.SetActive(false);
	}
}
