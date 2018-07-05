using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingLeftCycle : MonoBehaviour {

	[SerializeField]
	float moveSpeed = 5f;
	[SerializeField]
	float rightWayPoint = 8f, leftWayPoint = -8f;

	void Update(){
		transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime,transform.position.y);

		if(transform.position.x < leftWayPoint){
			transform.position = new Vector2(rightWayPoint,transform.position.y);
		}
	}
}
