using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plantAttack : MonoBehaviour {

	public Animator anim;
	public GameObject shootPoint;
	public GameObject beePrefab;

	void Start(){
			StartCoroutine(Hit());
	}

	IEnumerator Hit(){
		yield return new WaitForSeconds(5f);
		anim.SetBool("hit",true);
		yield return new WaitForSeconds(0.01f);
		anim.SetBool("hit",false);
		yield return new WaitForSeconds(0.5f);
		GameObject cloneBee = Instantiate(beePrefab,shootPoint.transform.position,Quaternion.identity);
	}
}
