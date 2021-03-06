﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InventoryControllerScript : MonoBehaviour {
	InvSlotScript[] slotScript;
	public InventoryScript invScript;
	public ItemManager manager;
	bool handFull;
	int itemInHand;
	public InvSlotScript[] slot;

	void Start () {
//		slot = new InvSlotScript[invScript.rows * invScript.collums];
		StartingInv();
	}

	void Update(){
//		for (int i = 0; i < slotScript.Length; i++) {
//			slotScript[i] = slot[i].GetComponent<InvSlotScript>();	
//		}
	}

    public void InititializeSlotAmount(int x, int y) {
        slot = new InvSlotScript[x * y];
		Debug.Log("Initializing slot amount!");

    }
	
	public void StartingInv(){
//        slot[0]._itemID = 0;
////		slot [1].itemID = 1;

//        //empty slots
//        for (int i = 1; i < slot.Length; i++) {
//            slot [i]._itemID = -1;		
//        }
	}

	public void Initialize(int index, InvSlotScript scr){
		slot [index] = scr;
	}


	public void slotPressed(int index){
		if (handFull) {
            if (slot[index]._itemID == -1)
            {
				slot[index]._itemID = itemInHand;
				itemInHand = -1;
				handFull = false;
			} else {
				int _temp = -1;
				_temp = itemInHand;
                itemInHand = slot[index]._itemID;
                slot[index]._itemID = _temp;
			}
		} else {
            if (slot[index]._itemID != -1)
            {
                itemInHand = slot[index]._itemID;
				handFull = true;
                slot[index]._itemID = -1;
			}
		}
		Debug.Log ("Button: " + index + " was clicked");
	}

	void OnGUI(){
		if (handFull) {
			GUI.DrawTexture(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y, 40, 40), manager.itemList[itemInHand].ItemIcon);
		}
	}
}