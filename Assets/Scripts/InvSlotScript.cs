using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InvSlotScript : MonoBehaviour {
	int _itemID, _stackSize;
	string slotIndex;
	InventoryControllerScript invController;

	void Start () {
		_itemID = 0;
		_stackSize = 0;
		slotIndex = transform.name;

		invController = GameObject.Find ("InventoryController").GetComponent<InventoryControllerScript> ();
	}

	public void thisClicked(){
		invController.slotPressed (slotIndex);
	}	

	public int itemID{
		get{return _itemID;}
		set{_itemID = value;}
	}

	public int stackSize{
		get{return _stackSize;}
		set{_stackSize = value;}
	}
}
