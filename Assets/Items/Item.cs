using UnityEngine;

public class Item : ScriptableObject{

	public string _name;
	public int _itemID;
	public RarityTypes _rarity;
	public int _value;
	public ItemType _itemType;

	public Texture2D _itemIcon; //added temp.
	public string _itemDesc; //added temp.

	public Item(){

		_itemID = 0;
		_name = "Need Name";
		_itemDesc = "Need Description";
		_rarity = RarityTypes.Normal;
		_value = 0;
		_itemIcon = null;
		_itemType = ItemType.Simple;
	}

	public Item(string name, string desciption, int itemID, RarityTypes rare, int value, Texture2D icon, ItemType type){
		_name = name;
		_itemDesc = desciption;
		_itemID = itemID;
		_rarity = rare;
		_value = value;
		_itemIcon = icon;
		_itemType = type;
	}

	public string Name{

		get{ return _name;}
		set{ _name = value;}
	}

	public string ItemDescription{	//added temp.

		get{return _itemDesc;}
		set{_itemDesc = value;}
	}

	public int ItemID{

		get{return _itemID;}
		set{_itemID = value;}
	}

	public RarityTypes Rarity{
		get{return _rarity;}
		set{_rarity = value;}
	}

	public int Value{
		get{return _value;}
		set{_value = value;}
	}

	public Texture2D ItemIcon{
		get{return _itemIcon;}
		set{_itemIcon = value;}
	}

	public ItemType ItemTypeV{
		get{return _itemType;}
		set{_itemType = value;}
	}
	
}
public enum ItemType {

	Simple,
	Weapon,
	Armor
}

public enum RarityTypes {

	Normal,
	Magical,
	Rare,
	Legendary
}
