using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class ItemDBManager : EditorWindow {

	[MenuItem("Custom Tools/Item Database Manager")]	

	static void Init(){
		ItemDBManager window = (ItemDBManager)EditorWindow.CreateInstance(typeof(ItemDBManager));
		window.Show();
	}

	enum ItemToCreate{
		Simple,
		Weapon,
		Armor
	}

	ItemManager itemManager;

	bool showingLists = false, showingWeapons = false, showingArmor = false, showingIDList = false;
	Vector2 scrollPos;
	string newItemName = "";
	string newItemDesc = "";
	Texture2D newItemIcon = null;
	int newItemID = 0;
	int newItemValue = 0;
	RarityTypes newItemRarity = RarityTypes.Normal;

	int newWeaponMaxDamage = 1;
	int newWeaponMinDamage = 0;
	DamageType newWeaponDamageType = DamageType.Slash;

	int newArmorLvl = 0;
    ArmorSlot newArmorSlot = ArmorSlot.Head;

	ItemToCreate currentItemToCreate = ItemToCreate.Weapon;

	public List<Item> _itemList;

	void OnFocus(){
//		itemManager = GameObject.Find ("InventoryController").GetComponent<ItemManager> () as ItemManager;
		itemManager = (ItemManager) GameObject.Find ("InventoryController").GetComponent<ItemManager> ();
		_itemList = itemManager.itemList;
	}

	void OnGUI(){
		if (itemManager != null) {

			List<WeaponItem> weaponList = new List<WeaponItem>();
			List<ArmorItem> armorList = new List<ArmorItem>();
			newItemID = _itemList.Count;

			for (int i = 0; i < _itemList.Count; i++){
				if (_itemList[i].GetType() == typeof(WeaponItem)){
					weaponList.Add((WeaponItem) _itemList[i]);
				}
				if (_itemList[i].GetType() == typeof(ArmorItem)){
					armorList.Add((ArmorItem) _itemList[i]);
				}
			}
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.PrefixLabel("Item Type: ");
			currentItemToCreate = (ItemToCreate)EditorGUILayout.EnumPopup (currentItemToCreate);
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.LabelField("General Attributes:", EditorStyles.boldLabel);
			newItemID = EditorGUILayout.IntField ("ID (BE CAREFUL): ", newItemID);
			newItemName = EditorGUILayout.TextField ("Name: ", newItemName);
			newItemDesc = EditorGUILayout.TextField ("Description: ", newItemDesc);
			newItemValue = EditorGUILayout.IntField ("Item Value: ", newItemValue);
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.PrefixLabel("Icon: ");
			newItemIcon = (Texture2D)EditorGUILayout.ObjectField (newItemIcon, typeof(Texture2D), true);
			EditorGUILayout.EndHorizontal();
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.PrefixLabel("Rarity: ");
			newItemRarity = (RarityTypes)EditorGUILayout.EnumPopup(newItemRarity);
			EditorGUILayout.EndHorizontal();


			switch(currentItemToCreate){
				case ItemToCreate.Weapon:
					EditorGUILayout.LabelField("Weapon-Specific Attributes:", EditorStyles.boldLabel);
					newWeaponMaxDamage = EditorGUILayout.IntField("Max Damage: ", newWeaponMaxDamage);
					newWeaponMinDamage = EditorGUILayout.IntField("Min Damage: ", newWeaponMinDamage);
					EditorGUILayout.BeginHorizontal();
					EditorGUILayout.PrefixLabel("Damage Type: ");
					newWeaponDamageType = (DamageType)EditorGUILayout.EnumPopup(newWeaponDamageType);
					EditorGUILayout.EndHorizontal();
					break;
				case ItemToCreate.Armor:
                    EditorGUILayout.LabelField("Armor-Specific Attributes:", EditorStyles.boldLabel);
                    EditorGUILayout.BeginHorizontal();
					EditorGUILayout.PrefixLabel("Armor Slot: ");
                    newArmorSlot = (ArmorSlot)EditorGUILayout.EnumPopup(newArmorSlot);
                    EditorGUILayout.EndHorizontal();
					newArmorLvl = EditorGUILayout.IntField("Armor Level: ", newArmorLvl);
					break;
			}

			if (GUILayout.Button("Add New Item")){
				switch(currentItemToCreate){
					case ItemToCreate.Weapon:
						WeaponItem newWeapon = (WeaponItem)ScriptableObject.CreateInstance<WeaponItem>();
						newWeapon.Name = newItemName;
						newWeapon.ItemDescription = newItemDesc;
						newWeapon.ItemID = newItemID;
						newWeapon.ItemIcon = newItemIcon;
						newWeapon.Value = newItemValue;
						newWeapon.Rarity = newItemRarity;
						newWeapon.MaxDamage = newWeaponMaxDamage;
						newWeapon.MinDamage = newWeaponMinDamage;
						newWeapon.TypeOfDamage = newWeaponDamageType;
						newWeapon.ItemTypeV = (ItemType) currentItemToCreate;
						_itemList.Add(newWeapon);
						break;
					case ItemToCreate.Armor:
						ArmorItem newArmor = (ArmorItem)ScriptableObject.CreateInstance<ArmorItem>();
						newArmor.Name = newItemName;
						newArmor.ItemDescription = newItemDesc;
						newArmor.ItemID = newItemID;
						newArmor.ItemIcon = newItemIcon;
						newArmor.Value = newItemValue;
						newArmor.Rarity = newItemRarity;
						newArmor.ArmorLevel = newArmorLvl;
                        newArmor.Slot = newArmorSlot;
						newArmor.ItemTypeV = (ItemType) currentItemToCreate;
						_itemList.Add(newArmor);
						break;
				}
			}

			EditorGUILayout.Space();

			showingLists = EditorGUILayout.Foldout(showingLists, "Item Database");
			EditorGUI.indentLevel = 2;


//			if (showingLists){
//				EditorGUILayout.LabelField("Total items: " + _itemList.Count);
//				EditorGUILayout.LabelField("Total weapons: " + weaponList.Count);
//				EditorGUILayout.LabelField("Total armor items: " + armorList.Count);
//				EditorGUILayout.Space();
//
//				scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
//				EditorGUI.indentLevel -= 1;
//				showingWeapons = EditorGUILayout.Foldout(showingWeapons, "Weapons");
//				if (showingWeapons){
//					EditorGUI.indentLevel += 2;
//					for (int i = 0; i < weaponList.Count; i++){
//						EditorGUILayout.BeginHorizontal();
//						EditorGUILayout.LabelField(weaponList[i].Name);
//						if (GUILayout.Button("-")){
//							_itemList.Remove(_itemList[i]);
//						}
//						EditorGUILayout.EndHorizontal();
//						EditorGUI.indentLevel +=1;
//						weaponList[i].ItemID = EditorGUILayout.IntField ("ID: ", weaponList[i].ItemID);
//						weaponList[i].Name = EditorGUILayout.TextField ("Name: ", weaponList[i].Name);
//						weaponList[i].ItemDescription = EditorGUILayout.TextField ("Description: ", weaponList[i].ItemDescription);
//						weaponList[i].Value = EditorGUILayout.IntField ("Value: ", weaponList[i].Value);
//						weaponList[i].MaxDamage = EditorGUILayout.IntField ("Max Damage: ", weaponList[i].MaxDamage);
//						weaponList[i].MinDamage = EditorGUILayout.IntField ("Min Damage: ", weaponList[i].MinDamage);
//						EditorGUILayout.BeginHorizontal();
//						EditorGUILayout.PrefixLabel("Damage Type: ");
//						weaponList[i].TypeOfDamage = (DamageType)EditorGUILayout.EnumPopup(weaponList[i].TypeOfDamage);
//						EditorGUILayout.EndHorizontal();
//						EditorGUI.indentLevel -=1;
//					}
//					EditorGUI.indentLevel -= 2;
//				}
//				showingArmor = EditorGUILayout.Foldout(showingArmor, "Armor Items");
//				if (showingArmor){
//					EditorGUI.indentLevel += 2;
//					for (int i = 0; i < armorList.Count; i++){
//						EditorGUILayout.BeginHorizontal();
//						EditorGUILayout.LabelField(armorList[i].Name);
//						if (GUILayout.Button("-")){
//							_itemList.Remove(_itemList[i]);
//						}
//						EditorGUILayout.EndHorizontal();
//						EditorGUI.indentLevel +=1;
//						armorList[i].ItemID = EditorGUILayout.IntField ("ID: ", armorList[i].ItemID);
//						armorList[i].Name = EditorGUILayout.TextField ("Name: ", armorList[i].Name);
//						armorList[i].ItemDescription = EditorGUILayout.TextField ("Description: ", armorList[i].ItemDescription);
//						armorList[i].Value = EditorGUILayout.IntField ("Value: ", armorList[i].Value);
//						armorList[i].ArmorLevel = EditorGUILayout.IntField("Armor Level: ", armorList[i].ArmorLevel);
//						EditorGUI.indentLevel -=1;
//					}
//					EditorGUI.indentLevel -= 2;
//				}
//				EditorGUILayout.EndScrollView();
//			}
			EditorGUI.indentLevel -= 2;
			showingIDList = EditorGUILayout.Foldout(showingIDList, "ID list");
			EditorGUI.indentLevel = 2;
			if (showingIDList){
				for (int i = 0; i < _itemList.Count; i++){
					EditorGUILayout.BeginHorizontal();
					EditorGUILayout.LabelField(_itemList[i].ItemID.ToString()+":\t"+_itemList[i].Name);
					if (GUILayout.Button("Edit")){
						AssetDatabase.OpenAsset(_itemList[i]);
					}
					if (GUILayout.Button("Remove")){
						if (EditorUtility.DisplayDialog("Are you sure you want to remove object?","Cannot be undone",
						                                "Remove", "Cancel"))
						_itemList.Remove(_itemList[i]);
					}
					EditorGUILayout.EndHorizontal();
				}
			}
//			if (showingLists = true) EditorGUILayout.EndScrollView();
		}
	}
}