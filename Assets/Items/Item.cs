using UnityEngine;

public class Item : ScriptableObject{

	public string _name;
	public int _value;
	public RarityTypes _rarity;
	public int _maxDurability;
	public int _curDurability;

	public Texture2D itemIcon; //added temp.
	public string _itemDesc; //added temp.

	public Item(){

		_name = "Need Name";
		_itemDesc = "Need Description";
		_value = 0;
		_rarity = RarityTypes.Normal;
		_maxDurability = 50;
		_curDurability = _maxDurability;
	}

	public Item(string name, string desciption, int value, RarityTypes rare, int maxDurability, int curDurability){
		_name = name;
		_itemDesc = desciption;
		_value = value;
		_rarity = rare;
		_maxDurability = maxDurability;
		_curDurability = curDurability;
		//TODO add Icon and Desc
	}

	public string Name{

		get{ return _name;}
		set{ _name = value;}
	}

	public string ItemDescription{	//added temp.

		get{return _itemDesc;}
		set{_itemDesc = value;}
	}

	public int Value{

		get{return _value;}
		set{_value = value;}
	}

	public RarityTypes Rarity{
		get{return _rarity;}
		set{_rarity = value;}
	}

	public int MaxDurability{
		get{return _maxDurability;}
		set{_maxDurability = value;}
	}

	public int CurDurability{
		get{return _curDurability;}
		set{_curDurability = value;}
	}
}

public enum RarityTypes {

	Normal,
	Magical,
	Rare,
	Legendary
}
