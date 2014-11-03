using UnityEngine;

public class ClothingItem : Item {

    public ArmorSlot _slot;

	public ClothingItem(){

		_slot = ArmorSlot.Head;
	}

	public ClothingItem(ArmorSlot slot){

		_slot = slot;
	}

	public ArmorSlot Slot{

		get{return _slot;}
		set{_slot = value;}
	}
}

public enum ArmorSlot{

	Head,
	Shoulders,
	Chest,
	Belt,
	Legs,
	Feet
}
