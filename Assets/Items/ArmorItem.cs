using UnityEngine;

public class ArmorItem : ClothingItem {

	public int _armorLevel;

	public ArmorItem(){

		_armorLevel = 0;
	}

	public ArmorItem(int al){

		_armorLevel = al;
	}

	public int ArmorLevel{

		get{return _armorLevel;}
		set{_armorLevel = value;}
	}
}
