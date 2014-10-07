using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

	public int maxHealth = 100;
	public int curHealth = 100;
	
	void Start () {
	}

	void Update () {
		if (curHealth >= maxHealth) {
			curHealth = maxHealth;		
		}
		if (curHealth <= 0) {
			curHealth = 0;		
		}
	}

	public void ApplyDamage(int damage){
		curHealth -= damage;
	}

	public void Heal(int heal){
		curHealth += heal;
	}
}
