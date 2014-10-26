using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class ItemDBManager : EditorWindow {

	[MenuItem("Project RPG Tools/Item DataBase Manager")]
	

	static void Init(){
		ItemDBManager window = (ItemDBManager)EditorWindow.CreateInstance(typeof(ItemDBManager));
		window.Show();
	}

	enum ItemToCreate{
		Weapon,
		Armor
	}

	ItemManager itemManager;

	bool showingLists = false, showingWeapons = false, showingArmor = false;
	Vector2 scrollPos;

	string newItemName = "";
	string newItemDesc = "";
	int newItemValue = 0;
	int newItemMaxDur = 50;
	int newItemCurDur = 50;
	RarityTypes newItemRarity = RarityTypes.Normal;

	int newWeaponMaxDamage = 0;
	float newWeaponDamageVar = 0;
	DamageType newWeaponDamageType = DamageType.Slash;

	int newArmorLvl = 0;

	ItemToCreate currentItemToCreate = ItemToCreate.Weapon;


	void OnFocus(){
		itemManager = GameObject.Find ("InventoryController").GetComponent<ItemManager> () as ItemManager;
	}

	void OnGUI(){
		if (itemManager != null) {

			List<WeaponItem> weaponList = new List<WeaponItem>();
			List<ArmorItem> armorList = new List<ArmorItem>();

			for (int i = 0; i < itemManager.itemList.Count; i++){
				if (itemManager.itemList[i].GetType() == typeof(WeaponItem)){
					weaponList.Add((WeaponItem)itemManager.itemList[i]);
				}
				if (itemManager.itemList[i].GetType() == typeof(ArmorItem)){
					armorList.Add((ArmorItem)itemManager.itemList[i]);
				}
			}
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.PrefixLabel("Item Type: ");
			currentItemToCreate = (ItemToCreate)EditorGUILayout.EnumPopup (currentItemToCreate);
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.LabelField("General Attributes:", EditorStyles.boldLabel);

			newItemName = EditorGUILayout.TextField ("Name: ", newItemName);
			newItemDesc = EditorGUILayout.TextField ("Description: ", newItemDesc);
			newItemValue = EditorGUILayout.IntField ("Value: ", newItemValue);
			newItemMaxDur = EditorGUILayout.IntField ("Max Item Durability: ", newItemMaxDur);
			newItemCurDur = EditorGUILayout.IntField ("Current Item Durability: ", newItemCurDur);
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.PrefixLabel("Rarity: ");
			newItemRarity = (RarityTypes)EditorGUILayout.EnumPopup(newItemRarity);
			EditorGUILayout.EndHorizontal();


			switch(currentItemToCreate){
				case ItemToCreate.Weapon:
					EditorGUILayout.LabelField("Weapon-Specific Attributes:", EditorStyles.boldLabel);
					newWeaponMaxDamage = EditorGUILayout.IntField("Max Damage: ", newWeaponMaxDamage);
					newWeaponDamageVar = EditorGUILayout.FloatField("Damage Variation: ", newWeaponDamageVar);
					EditorGUILayout.BeginHorizontal();
					EditorGUILayout.PrefixLabel("Damage Type: ");
					newWeaponDamageType = (DamageType)EditorGUILayout.EnumPopup(newWeaponDamageType);
					EditorGUILayout.EndHorizontal();
					break;
				case ItemToCreate.Armor:
					EditorGUILayout.LabelField("Armor-Specific Attributes:", EditorStyles.boldLabel);
					newArmorLvl = EditorGUILayout.IntField("Armor Level: ", newArmorLvl);
					break;
			}

			if (GUILayout.Button("Add New Item")){
				switch(currentItemToCreate){
					case ItemToCreate.Weapon:
						WeaponItem newWeapon = (WeaponItem)ScriptableObject.CreateInstance<WeaponItem>();
						newWeapon.Name = newItemName;
						newWeapon.ItemDescription = newItemDesc;
						newWeapon.Value = newItemValue;
						newWeapon.MaxDurability = newItemMaxDur;
						newWeapon.CurDurability = newItemCurDur;
						newWeapon.Rarity = newItemRarity;
						newWeapon.MaxDamage = newWeaponMaxDamage;
						newWeapon.DamageVariance = newWeaponDamageVar;
						newWeapon.TypeOfDamage = newWeaponDamageType;
						itemManager.itemList.Add(newWeapon);
						break;
					case ItemToCreate.Armor:
						ArmorItem newArmor = (ArmorItem)ScriptableObject.CreateInstance<ArmorItem>();
						newArmor.Name = newItemName;
						newArmor.ItemDescription = newItemDesc;
						newArmor.Value = newItemValue;
						newArmor.MaxDurability = newItemMaxDur;
						newArmor.CurDurability = newItemCurDur;
						newArmor.Rarity = newItemRarity;
						newArmor.ArmorLevel = newArmorLvl;
						itemManager.itemList.Add(newArmor);
						break;
				}
			}

			EditorGUILayout.Space();

			showingLists = EditorGUILayout.Foldout(showingLists, "Item Database");
			EditorGUI.indentLevel = 2;


			if (showingLists){
				EditorGUILayout.LabelField("Total items: " + itemManager.itemList.Count);
				EditorGUILayout.LabelField("Total weapons: " + weaponList.Count);
				EditorGUILayout.LabelField("Total armor items: " + armorList.Count);
				EditorGUILayout.Space();

				scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
				EditorGUI.indentLevel -= 1;
				showingWeapons = EditorGUILayout.Foldout(showingWeapons, "Weapons");
				if (showingWeapons){
					EditorGUI.indentLevel += 2;
					for (int i = 0; i < weaponList.Count; i++){
						EditorGUILayout.BeginHorizontal();
						EditorGUILayout.LabelField(weaponList[i].Name);
						if (GUILayout.Button("-")){
							itemManager.itemList.Remove(itemManager.itemList[i]);
						}
						EditorGUILayout.EndHorizontal();
						EditorGUI.indentLevel +=1;
						weaponList[i].Name = EditorGUILayout.TextField ("Name: ", weaponList[i].Name);
						weaponList[i].ItemDescription = EditorGUILayout.TextField ("Description: ", weaponList[i].ItemDescription);
						weaponList[i].Value = EditorGUILayout.IntField ("Value: ", weaponList[i].Value);
						weaponList[i].MaxDurability = EditorGUILayout.IntField ("Max Dur: ", weaponList[i].MaxDurability);
						weaponList[i].CurDurability = EditorGUILayout.IntField ("Current Dur: ", weaponList[i].CurDurability);
						weaponList[i].MaxDamage = EditorGUILayout.IntField ("Max Damage: ", weaponList[i].MaxDamage);
						weaponList[i].DamageVariance = EditorGUILayout.FloatField ("Damage Var: ", weaponList[i].DamageVariance);
						EditorGUILayout.BeginHorizontal();
						EditorGUILayout.PrefixLabel("Damage Type: ");
						weaponList[i].TypeOfDamage = (DamageType)EditorGUILayout.EnumPopup(weaponList[i].TypeOfDamage);
						EditorGUILayout.EndHorizontal();
						EditorGUI.indentLevel -=1;
					}
					EditorGUI.indentLevel -= 2;
				}
				showingArmor = EditorGUILayout.Foldout(showingArmor, "Armor Items");
				if (showingArmor){
					EditorGUI.indentLevel += 2;
					for (int i = 0; i < armorList.Count; i++){
						EditorGUILayout.BeginHorizontal();
						EditorGUILayout.LabelField(armorList[i].Name);
						if (GUILayout.Button("-")){
							itemManager.itemList.Remove(itemManager.itemList[i]);
						}
						EditorGUILayout.EndHorizontal();
						EditorGUI.indentLevel +=1;
						armorList[i].Name = EditorGUILayout.TextField ("Name: ", armorList[i].Name);
						armorList[i].ItemDescription = EditorGUILayout.TextField ("Description: ", armorList[i].ItemDescription);
						armorList[i].Value = EditorGUILayout.IntField ("Value: ", armorList[i].Value);
						armorList[i].MaxDurability = EditorGUILayout.IntField ("Max Dur: ", armorList[i].MaxDurability);
						armorList[i].CurDurability = EditorGUILayout.IntField ("Current Dur: ", armorList[i].CurDurability);
						armorList[i].ArmorLevel = EditorGUILayout.IntField("Armor Level: ", armorList[i].ArmorLevel);
						EditorGUI.indentLevel -=1;
					}
					EditorGUI.indentLevel -= 2;
				}
				EditorGUILayout.EndScrollView();
			}
		}
	}
}
