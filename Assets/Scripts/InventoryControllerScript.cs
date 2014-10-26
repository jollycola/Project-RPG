using UnityEngine;
using System.Collections;

public class InventoryControllerScript : MonoBehaviour {
	InvSlotScript slotScript;
	bool itemInHand;

	void Start () {

	}

	void Update () {
	
	}

	public void slotPressed(string index){
		if (itemInHand) {
			
		} else {
			
		}
		Debug.Log ("Button: " + index + " was clicked");
	}
}
