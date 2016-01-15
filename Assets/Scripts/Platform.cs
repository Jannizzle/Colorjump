using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour
{

	public bool moving = false;
	public float speed;
	public float amount;
	Vector3 origin;
	Rigidbody2D rigid;

	//0-up,1-down,2-left,3-right
	//int dir = 0;

	public enum Direction
	{
		up,
		down,
		left,
		right}

	;

	public Direction dir;

	float borderTop;
	float borderBot;
	float borderLeft;
	float borderRight;

	public Color col;
	Renderer[] rend;

	// Use this for initialization
	void Start ()
	{
		origin = transform.position;
		borderTop = origin.y + amount / 2;
		borderBot = origin.y - amount / 2;
		borderLeft = origin.x - amount / 2;
		borderRight = origin.x + amount / 2;

		rigid = gameObject.GetComponent<Rigidbody2D> ();

		rend = gameObject.GetComponentsInChildren<Renderer>();
		foreach (Renderer renderer in rend) {
			renderer.material.color = col;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{

		if (moving) {
			switch (dir) {
			case Direction.up:
				if (transform.position.y <= borderTop) {
					transform.Translate (Vector2.up * Time.deltaTime * speed);
				} else {
					dir = Direction.down;
				}
				break;
			case Direction.down:
				if (transform.position.y >= borderBot) {
					transform.Translate (Vector2.down * Time.deltaTime * speed);
				} else {
					dir = Direction.up;
				}
				break;
			case Direction.left:
				if (transform.position.x >= borderLeft) {
					transform.Translate (Vector2.left * Time.deltaTime * speed);
				} else {
					dir = Direction.right;
				}
				break;
			case Direction.right:
				if (transform.position.x <= borderRight) {
					transform.Translate (Vector2.right * Time.deltaTime * speed);
				} else {
					dir = Direction.left;
				}
				break;
			}
		}
	
	}
}
