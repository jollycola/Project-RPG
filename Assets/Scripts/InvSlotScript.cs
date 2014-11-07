using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InvSlotScript : MonoBehaviour {
	public int _itemID, _stackSize, _slotIndex;
	Texture2D _iconToDraw;
	public bool mouseOver = false;
	public RawImage imageSlot;
	public InventoryControllerScript invController;
	public ItemManager manager;
	public RectTransform rectT;
	public Rect tooltipWindow;

	ArmorItem _tempArmor;
	WeaponItem _tempWeapon;

	void Start () {
		_stackSize = 0;
		_iconToDraw = null;
	}

	void Update(){
		if (_itemID != -1) {
			_iconToDraw = manager.itemList[_itemID].ItemIcon;
			_tempArmor = manager.itemList[_itemID] as ArmorItem;
			_tempWeapon = manager.itemList[_itemID] as WeaponItem;
		} else { _iconToDraw = null;}
		if (_iconToDraw != null) {
			imageSlot.color = new Color(1,1,1,1);
			imageSlot.texture = _iconToDraw;
		} else {
			imageSlot.color = new Color(0,0,0,0);
		}

	}
	public void Initialize(){
		invController.Initialize (_slotIndex, this);
        //Debug.Log(_slotIndex);
	}

	public void thisClicked(){
		invController.slotPressed (_slotIndex);
	}	

	public int itemID{
		get{return _itemID;}
		set{_itemID = value;}
	}

	public int SlotIndex{
		get{return _slotIndex;}
		set{_slotIndex = value;}
	}

	public int stackSize{
		get{return _stackSize;}
		set{_stackSize = value;}
	}

	public bool MouseOver{
		get{return mouseOver;}
		set{mouseOver = value;}
	}
	

	void OnGUI(){
		if (mouseOver && _itemID != -1) {
            //Debug.Log ("Mouse Over: "+ _slotIndex);
			tooltipWindow = GUI.Window(0, tooltipWindow, inTooltip, manager.itemList[_itemID].Name + "("+ manager.itemList[_itemID].Rarity+")");
			tooltipWindow.position = Event.current.mousePosition;
		}
	}
	
	void inTooltip(int windowID)
	{
		GUILayout.TextArea (manager.itemList[_itemID].ItemDescription);
		switch (manager.itemList[_itemID].ItemTypeV) {
		case ItemType.Armor: GUILayout.Label ("Armor: "+ _tempArmor.ArmorLevel); break;
		case ItemType.Weapon: GUILayout.Label ("Damage: "+ _tempWeapon.MinDamage+"-"+_tempWeapon.MaxDamage); break;
		}
		GUI.color = Color.yellow;
		GUILayout.Label ("Value: "+ manager.itemList[_itemID].Value+ " gold");
		GUI.color = Color.white;
	}
}
