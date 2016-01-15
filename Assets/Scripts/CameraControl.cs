using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{

	GameObject player;
	int posX;
	int posY;
	float origZ;
	public Transform goal;
	Vector3 diff;
	Camera camera;


	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		origZ = transform.position.z;
		camera = gameObject.GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update ()
	{


		if (Input.GetButton ("Fire2")) {
			panToGoal ();
		} else {
			transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, transform.position.z);
			//transform.Translate (new Vector3 (Mathf.Abs (goal.position.x - transform.position.x), Mathf.Abs (goal.position.y - transform.position.y), transform.position.z));
		}
		if (Input.GetKeyDown ("p")) {
			adjustCamera (0);
		}
		if (Input.GetKeyDown ("o")) {
			adjustCamera (1);
		}
	
	}

	void panToGoal ()
	{
		goal = GameObject.FindGameObjectWithTag ("Goal").transform;
		diff = new Vector3 (goal.position.x - transform.position.x, goal.position.y - transform.position.y, origZ);
		transform.Translate (diff * Time.deltaTime * 2.0f);
		Debug.Log (diff);

	}

	void adjustCamera (int mode)
	{
		if (mode == 0) {
			camera.orthographicSize = camera.orthographicSize + 5;
		}
		if (mode == 1) {
			camera.orthographicSize = camera.orthographicSize - 5;
		}
	}
}
