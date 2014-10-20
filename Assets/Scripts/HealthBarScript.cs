using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBarScript : MonoBehaviour {
	public GameObject player;
	private HealthScript healthScript;
	public Slider slider;
	
	void Start () {
		healthScript = player.GetComponent<HealthScript> ();
	}

	void Update () {
		float pHealth = ((float) healthScript.curHealth /(float) healthScript.maxHealth);
		slider.value = pHealth;
	}
}
