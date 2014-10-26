using UnityEngine;
using System.Collections;

[System.Serializable]
public class WeaponItem : Item {
	
	public int _maxDamage;
	public float _dmgVar;
	public DamageType _dmgType;
	
	public WeaponItem(){
		
		_maxDamage = 0;
		_dmgVar = 0;
		_dmgType = DamageType.Slash;
	}

	public WeaponItem(int mDmg, float dmgV, DamageType dmgT){
		
		_maxDamage = mDmg;
		_dmgVar = dmgV;
		_dmgType = dmgT;
	}
	
	public int MaxDamage{
		
		get{return _maxDamage;}
		set{_maxDamage = value;}
	}
	
	public float DamageVariance{
		
		get{return _dmgVar;}
		set{_dmgVar = value;}
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
