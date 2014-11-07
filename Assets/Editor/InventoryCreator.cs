using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Collections;

public class InventoryCreator : EditorWindow {

    [MenuItem("Custom Tools/Inventory Creator")]

	static void Init () {
        InventoryCreator window = (InventoryCreator)EditorWindow.CreateInstance(typeof(InventoryCreator));
        window.Show();
	}

    Vector2 amountOfSlots;
    int distanceBetweenSlots = 53;
    //public gameobject slotprefab, title, background, invparent;
    GameObject slotPrefab;
    Transform parent_slot;
    //public transform parent_slot;
    //public guistyle guistyle;
    InventoryControllerScript invControlSrcipt;
    ItemManager _manager;

    void OnFocus()
    {
		parent_slot = (Transform) GameObject.Find("Inventory").GetComponent<Transform>();
        invControlSrcipt = (InventoryControllerScript)GameObject.Find("InventoryController").GetComponent<InventoryControllerScript>();
        _manager = (ItemManager)GameObject.Find("InventoryController").GetComponent<ItemManager>();
    }

    void OnGUI() {
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.PrefixLabel("Slot Prefab: ");
        slotPrefab = (GameObject)EditorGUILayout.ObjectField(slotPrefab, typeof(GameObject));
        EditorGUILayout.EndHorizontal();
        amountOfSlots = EditorGUILayout.Vector2Field("Amount of slots: ", amountOfSlots);
        distanceBetweenSlots = EditorGUILayout.IntField("Distance between slots: ", distanceBetweenSlots);
        EditorGUILayout.Space();

        //EditorGUILayout.LabelField("Starting Inventory", EditorStyles.boldLabel);
        //for (int i = 0; i < amountOfSlots.y; i++)
        //{
        //    for (int ii = 0; ii < amountOfSlots.x; ii++)
        //    {
        //        EditorGUILayout.IntField("Item ID: ", );
        //    }
        //}
        //EditorGUILayout.Space();

        if (GUILayout.Button("Create Inventory"))
        {
            float _halfCollums = (float)amountOfSlots.x / 2 - 0.5f;
            float _halfRows = (float)amountOfSlots.y / 2 - 0.5f;
            RectTransform slotRectTransform = slotPrefab.GetComponent<RectTransform>();
            //invControlSrcipt.InititializeSlotAmount();
            invControlSrcipt.slot = new InvSlotScript[(int)amountOfSlots.x * (int)amountOfSlots.y];
            for (int i = 0; i < amountOfSlots.y; i++)
            {
                float _i = i - _halfRows;
                for (int ii = 0; ii < amountOfSlots.x; ii++)
                {
                    GameObject slot;
                    float _ii = ii - _halfCollums;
                    slot = Instantiate(slotPrefab) as GameObject;
                    slot.transform.localScale = new Vector3((float)slot.transform.localScale.x / (1920 / Camera.main.pixelWidth), (float)slot.transform.localScale.y / (1920 / Camera.main.pixelWidth), (float)slot.transform.localScale.z);
                    slot.name = "slot_" + (i * amountOfSlots.x + ii);
                    slot.transform.parent = parent_slot;
                    float _realDistance = distanceBetweenSlots * slot.transform.localScale.x;
                    //slot.transform.localPosition = new Vector3(_ii * (slotRectTransform.sizeDelta.x + distanceBetweenSlots), -_i * (slotRectTransform.sizeDelta.y + distanceBetweenSlots), 0);
                    slot.transform.localPosition = new Vector3(_ii * (slot.transform.localScale.x + _realDistance), -_i * (slot.transform.localScale.y + _realDistance), 0);
                    //slot.GetComponentInChildren<Text>().text = "" + (i * amountOfSlots.x + ii);
                    slot.GetComponent<InvSlotScript>()._slotIndex = (int)(i * amountOfSlots.x + ii);
                    slot.GetComponent<InvSlotScript>()._itemID = -1;
                    slot.GetComponent<InvSlotScript>().invController = invControlSrcipt;
                    slot.GetComponent<InvSlotScript>().manager = _manager;
                    slot.GetComponent<InvSlotScript>().Initialize();
                }
            }
        }
        
    }
}
