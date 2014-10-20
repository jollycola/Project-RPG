using UnityEngine;
using System.Collections;

public class PlayerNavigation : MonoBehaviour {

	NavMeshAgent agent;
	Vector3 clickPosition;	
	public GameObject positionIndicator, arrow;
	public HealthScript health;
	public Animator clickAnimator;

	float time = 0.5f;

	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		clickPosition = transform.position;
		health = this.GetComponent<HealthScript> ();

	}

	void Update () {
		if (Input.GetMouseButton (1)) {
			GetMousePosition();
		}

		if (Vector3.Distance (clickPosition, transform.position) <= 4) {
			time -= Time.deltaTime;
			clickAnimator.SetTrigger("Disappear");
			if(time <=0){
				positionIndicator.SetActive(false);
				time = 0;
			}
		}
	}

	void FixedUpdate(){
	}

	void GetMousePosition(){
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		
		if(Physics.Raycast(ray, out hit, 1000)){
			clickPosition = new Vector3(hit.point.x, hit.point.y, hit.point.z);
			Debug.Log(clickPosition);
			
		}
		placeMarker();

		time = 0.5f;
	}

	void placeMarker() {
		positionIndicator.SetActive (true);
		positionIndicator.transform.position = clickPosition;
		arrow.transform.position = new Vector3 (positionIndicator.transform.position.x, 200, positionIndicator.transform.position.z);
		agent.SetDestination (clickPosition);
		clickAnimator.SetTrigger ("Appear");
	}
}
