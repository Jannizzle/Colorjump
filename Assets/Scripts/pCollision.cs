using UnityEngine;
using System.Collections;

public class pCollision : MonoBehaviour
{

	GameObject player;
	GameObject feet;
	pMovement pm;
	Renderer rend;
	Renderer other;

	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		feet = GameObject.FindGameObjectWithTag ("Feet");
		pm = player.GetComponent<pMovement> ();
		rend = GetComponent<Renderer> ();
	}

	public void OnCollisionEnter2D (Collision2D collision)
	{

		if (collision.gameObject.tag == "Goal") {
			Debug.Log ("Goal");
			pm.setOnFloor (true);
		} else {

			if (collision.gameObject.tag == "Floor") {
				pm.setOnFloor (true);

			}
			if (collision.gameObject.tag == "Wall") {
				if (player.transform.position.x > collision.transform.position.x) {
					pm.setOnWall (true, 1);
				} else {
					pm.setOnWall (true, -1);
				}


			}
		}
		other = collision.gameObject.GetComponent<Renderer> ();
		if (rend.material.color == Color.white && collision.gameObject.tag != "Goal") {
			rend.material.color = other.material.color;
		}
		if (other.material.color == rend.material.color && collision.gameObject.tag == "Goal") {
			Debug.Log ("Hurray");
		}
		if (other.material.color == Color.white) {

		} else if (collision.gameObject.tag != "Goal") {
			rend.material.color = (rend.material.color + other.material.color) / 2;
		}





	}

	public void OnCollisionExit2D (Collision2D collision)
	{
		if (collision.gameObject.tag == "Wall") {
			pm.setOnWall (false, 1);
		}

		if (collision.gameObject.tag == "Floor") {
			pm.setOnFloor (false);

		}
	}





}
		

