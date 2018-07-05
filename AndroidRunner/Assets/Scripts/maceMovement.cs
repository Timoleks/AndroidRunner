using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maceMovement : MonoBehaviour {

	private float movementSpeed = 5f;
	private float posY1 = 5f;
	private float posY2 = 2.42f;
	private bool moveDown = false;

	void Update () {
		
			if(transform.position.y > posY2 && moveDown == false)
				moveDown = false;

			if(transform.position.y > posY1)
				moveDown = true;

			if(moveDown){
				transform.position += Vector3.down * Time.deltaTime * movementSpeed;
				if(transform.position.y < posY2 && moveDown == true)
					moveDown = false;
			}
			if(!moveDown)
				transform.position += Vector3.up * Time.deltaTime * movementSpeed;

	}
}
