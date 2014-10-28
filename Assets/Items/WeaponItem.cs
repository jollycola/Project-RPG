using UnityEngine;
using System.Collections;

[System.Serializable]
public class WeaponItem : Item {
	
	public int _maxDamage;
	public int _minDamage;
	public DamageType _dmgType;
	
	public WeaponItem(){
		
		_maxDamage = 0;
		_minDamage = 0;
		_dmgType = DamageType.Slash;
	}

	public WeaponItem(int maxDmg, int minDmg, DamageType dmgT){
		
		_maxDamage = maxDmg;
		_minDamage = minDmg;
		_dmgType = dmgT;
	}
	
	public int MaxDamage{
		
		get{return _maxDamage;}
		set{_maxDamage = value;}
	}
	
	public int MinDamage{
		
		get{return _minDamage;}
		set{_minDamage = value;}
	}
	
	public DamageType TypeOfDamage{
		
		get{return _dmgType;}
		set{_dmgType = value;}
	}
}

public enum DamageType{
	
	Slash,
	Pierce,
	Crush,
	Fire,
	Ice,
	Lightening,
	Acid
}
