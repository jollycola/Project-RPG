using UnityEngine;
using System.Collections;

public class ClickToMove : MonoBehaviour {

	Vector3 clickPosition;
	public float speed = 5;

	public GameObject positionIndicator;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {
			GetMousePosition();
		}
	}

	void FixedUpdate(){
		MoveToPoint ();
	}

	void GetMousePosition(){
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		if(Physics.Raycast(ray, out hit, 1000)){
			clickPosition = new Vector3(hit.point.x, hit.point.y, hit.point.z);
			Debug.Log(clickPosition);

		}
	}

	void MoveToPoint(){
		if (Vector3.Distance (transform.position, clickPosition) > 2.5) {
			Quaternion newRotate = Quaternion.LookRotation (clickPosition - transform.position, transform.forward);
			newRotate.x = 0;
			newRotate.z = 0;
			transform.rotation = Quaternion.Slerp (transform.rotation, newRotate, 0.1f);

			rigidbody.AddForce(transform.forward*speed);

			placeMarker();
		}

	}

	void placeMarker() {
		positionIndicator.SetActive (true);
		positionIndicator.transform.position = clickPosition;
	}
}
