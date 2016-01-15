using UnityEngine;
using System.Collections;

public class pMovement : MonoBehaviour
{

	float inputVectorX = 0;
	public float speed;
	public float jumpHeight;
	float origin;
	Rigidbody2D rigid;

	public int jumpcount = 2;
	public bool onFloor = true;
	public bool onWall = false;
	public float wallJumpDir = 1;

	Vector3 start;
	Renderer rend;

	// Use this for initialization
	void Start ()
	{
		rigid = GetComponent<Rigidbody2D> ();
		start = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		rend = GetComponent<Renderer> ();

	}

	void Update ()
	{
		if (Input.GetButtonDown ("Fire1")) {
			if (onWall) {
				wallJump ();
			} else {
				Jump ();
			}
		} 
		if (Input.GetButtonDown ("Fire3")) {
			Reset ();
		} 
			
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		inputVectorX = Input.GetAxis ("Horizontal") * speed;
		transform.position = new Vector2 (transform.position.x + inputVectorX, transform.position.y);


	}

	void Jump ()
	{
		if (jumpcount > 0) {
			origin = transform.position.y;
			rigid.velocity = Vector3.zero;
			rigid.AddForce (Vector2.up * jumpHeight);
			//transform.position = new Vector2 (transform.position.x, transform.position.y + jumpHight * Time.deltaTime);
			jumpcount--;
		}
	}

	public void wallJump ()
	{
		rigid.velocity = Vector3.zero;
		if (wallJumpDir == 1) {
			rigid.AddForce ((Vector2.up + Vector2.right) * jumpHeight / 2);
		}
		if (wallJumpDir == -1) {
			rigid.AddForce ((Vector2.up + Vector2.left) * jumpHeight / 2);
		}

		onWall = false;
	}

	void Reset ()
	{
		transform.position = start;
		rend.material.color = Color.white;
		rigid.velocity = Vector3.zero;
	}

	public void setOnFloor (bool state)
	{
		//rigid.velocity = Vector3.zero;
		onFloor = state;
		if (state) {
			jumpcount = 2;
		}
	}

	public void setOnWall (bool state, float dir)
	{
		onWall = state;
		wallJumpDir = dir;
	}


}
