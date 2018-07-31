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
	public static bool isPlayerAlive = true;
	public GameObject beePref;

	private Collider2D myCollider;
	private float jumpForce = 350f;
	float speedForce = 4f;
	float horizontal;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		if(anim == null)
		{
			anim = GetComponent<Animator>();
		}

		myCollider = GetComponent<CircleCollider2D>();
		horizontal = CrossPlatformInputManager.GetAxisRaw("Horizontal");
	}


	void movingPlayer()
	{
		if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
		{
				jumpPlayer();
		}
		grounded = Physics2D.IsTouchingLayers(myCollider,whatIsGround);

		if(horizontal > 0)
		{
			anim.SetInteger("state",1);
		}
	}

	void InitCBT()
	{
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

	void Flip()
	{
		if(Input.GetAxis("Horizontal") < 0 )
		{
			transform.localRotation = Quaternion.Euler(0,180,0);
		}
		if(horizontal > 0 )
		{
			transform.localRotation = Quaternion.Euler(0,0,0);
		}
	}
	void Update()
	{
		if(isPlayerAlive)
		{
			movingPlayer();
		}
	}
	void FixedUpdate()
	{
		//Debug.Log(Vector2.Distance(new Vector2(transform.position.x,0),new Vector2(beePref.transform.position.x,transform.position.y)));
		horizontal = 1;
		rb.velocity = new Vector2(horizontal * speedForce,rb.velocity.y);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Obstacles")
		{
			if(damage != 0f)
			{
				if(health > 50f)
					FindObjectOfType<AudioManager>().Play("SpikeHit");

				TakeDamage(damage);
		  }
		}

	}

public void TakeDamage(float amount)
	{
		InitCBT();
		health -= amount;
		Debug.Log("Health: " + health);
		if(health <= 0f)
		{
			if(player != null)
			Death();

		}
	}

	void Death()
	{
			Destroy(player);
			isPlayerAlive = false;
			scoreManager.highScoreCount = scoreManager.scoreCount;
			SaveHighScore();
			scoreManager.scoreCount = 0f;
			FindObjectOfType<AudioManager>().Play("Death");
	}

	public void jumpPlayer()
	{
		if(grounded && !PauseMenu.GameIsPaused)
			rb.AddForce(new Vector2(0,jumpForce));
	}

	public void SaveHighScore()
	{
		if(scoreManager.highScoreCount > PlayerPrefs.GetFloat("HighScore",0f))
			PlayerPrefs.SetFloat("HighScore",Mathf.Round(scoreManager.highScoreCount));
	}

}
