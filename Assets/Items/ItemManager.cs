using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemManager : MonoBehaviour {

	public List<Item> itemList = new List<Item> ();

	public List<WeaponItem> _weaponList = new List<WeaponItem>();
	public List<ArmorItem> _armorList = new List<ArmorItem>();

	void Start(){
		for (int i = 0; i < itemList.Count; i++){
			//				_itemList[i].ItemID = i;
			if (itemList[i].GetType() == typeof(WeaponItem)){
				_weaponList.Add((WeaponItem)itemList[i]);
			}
			if (itemList[i].GetType() == typeof(ArmorItem)){
				_armorList.Add((ArmorItem)itemList[i]);
			}
		}
	}
}
