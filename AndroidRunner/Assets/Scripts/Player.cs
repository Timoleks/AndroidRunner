using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
public class Player : MonoBehaviour {

	Rigidbody2D rb;
	public Animator anim;
	public LayerMask whatIsGround;
	public bool grounded;
	public float health = 100f;
	public static float damage = 50f;
	public GameObject CBTprefab;
	public  GameObject player;

	private Collider2D myCollider;
	private float jumpForce = 350f;
	float speedForce = 4f;
	float horizontal;
	void Start(){
		rb = GetComponent<Rigidbody2D>();
		if(anim == null){
			anim = GetComponent<Animator>();
		}

		myCollider = GetComponent<CircleCollider2D>();
		horizontal = CrossPlatformInputManager.GetAxisRaw("Horizontal");
	}
	void Update(){
		if(Input.GetMouseButtonDown(0)){
				jumpPlayer();
		}
		grounded = Physics2D.IsTouchingLayers(myCollider,whatIsGround);

		if(horizontal > 0){
			anim.SetInteger("state",1);
		}
	}
	void InitCBT(){
		GameObject temp = Instantiate(CBTprefab);
		RectTransform tempRect = temp.GetComponent<RectTransform>();
		temp.transform.SetParent(transform.Find("PopUpCanvas"));
		tempRect.transform.localPosition = CBTprefab.transform.localPosition;
		tempRect.transform.localScale = CBTprefab.transform.localScale;
		tempRect.transform.localRotation = CBTprefab.transform.localRotation;
		//temp.GetComponent<Text>().text = text;
		//temp.GetComponent<Animator>().SetTrigger("Hit");
		Destroy(temp,2f);
	}
	void Flip(){
		if(Input.GetAxis("Horizontal") < 0 ){
			transform.localRotation = Quaternion.Euler(0,180,0);
		}
		if(horizontal > 0 ){
			transform.localRotation = Quaternion.Euler(0,0,0);
		}
	}
	void FixedUpdate(){
		horizontal = 1;
		rb.velocity = new Vector2(horizontal * speedForce,rb.velocity.y);
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Obstacles"){
			if(damage != 0f){
			TakeDamage(damage);
			Debug.Log("Health: " + health);
		}
		}
	}
	void TakeDamage(float amount){
		InitCBT();
		health -= amount;
		if(health <= 0f){
			if(player != null)
			Death();
		}
	}
	void Death(){
			Destroy(player);
	}
	public void jumpPlayer(){
		if(grounded)
			rb.AddForce(new Vector2(0,jumpForce));
	}
}
