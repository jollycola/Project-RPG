using UnityEngine;
using System.Collections;

public class PlayerNavigation : MonoBehaviour {

	NavMeshAgent agent;
	Vector3 clickPosition;	
	public GameObject positionIndicator;
	public HealthScript health;

	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		clickPosition = transform.position;
	}

	void Update () {
		if (Input.GetMouseButton (1)) {
			GetMousePosition();
		}

		if (Vector3.Distance (clickPosition, transform.position) <= 1) {
			positionIndicator.SetActive(false);		
		}
	}

	void FixedUpdate(){
//		health.ApplyDamage (1);
	}

	void GetMousePosition(){
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		
		if(Physics.Raycast(ray, out hit, 1000)){
			clickPosition = new Vector3(hit.point.x, hit.point.y, hit.point.z);
			Debug.Log(clickPosition);
			
		}
		placeMarker();
	}

	void placeMarker() {
		positionIndicator.SetActive (true);
		positionIndicator.transform.position = clickPosition;
		agent.SetDestination (clickPosition);
	}
}
