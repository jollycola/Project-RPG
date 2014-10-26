using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InventoryScript : MonoBehaviour {

	public int collums, rows, distanceBetweenSlots=0;
	public GameObject slotPrefab, title, background, invParent;
	public Transform parent_slot;
    public Rect windowRect;
	public GUIStyle guiStyle;

	void Start () {	
        int slotNumber = 0;
		float _halfCollums = (float)collums / 2 - 0.5f;
		float _halfRows = (float)rows / 2 - 0.5f;
		RectTransform slotRectTransform = slotPrefab.GetComponent<RectTransform> (); 
		for (int i = 0; i < rows; i++) {
			float _i = i - _halfRows;
			for (int ii = 0; ii < collums; ii++) {
				GameObject slot;
				float _ii = ii - _halfCollums;

				slot = Instantiate (slotPrefab) as GameObject;
				slot.name = "slot_"+i+"_"+ii;
				slot.transform.parent = parent_slot;
				slot.transform.localPosition = new Vector3(_ii * (slotRectTransform.sizeDelta.x + distanceBetweenSlots), -	_i * (slotRectTransform.sizeDelta.y+distanceBetweenSlots), 0);
            	slot.GetComponentInChildren<Text>().text = ""+i+"_"+ii;

            	slotNumber++;
			}
		}
        float mX = 0;
        if (IsOdd(rows)) { mX = 0.5f; }
        GameObject.Find("Title").transform.localPosition = new Vector3(title.transform.localPosition.x, (rows / 2 + mX) * slotRectTransform.sizeDelta.y + slotRectTransform.sizeDelta.y + (rows / 2 + mX) * distanceBetweenSlots);
        RectTransform bg_rectTransform = background.GetComponent<RectTransform>();

        bg_rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left,
            -_halfCollums * slotRectTransform.sizeDelta.x + -_halfCollums * distanceBetweenSlots,
            (collums * slotRectTransform.sizeDelta.x + slotRectTransform.sizeDelta.x + collums * distanceBetweenSlots));

        bg_rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom,
            -_halfRows * slotRectTransform.sizeDelta.y + -_halfCollums * distanceBetweenSlots,
            (rows * slotRectTransform.sizeDelta.y + slotRectTransform.sizeDelta.y * 2 + rows * distanceBetweenSlots + (slotRectTransform.sizeDelta.y * 0.5f)));

        windowRect = new Rect(_halfCollums * slotRectTransform.sizeDelta.x + -_halfCollums * distanceBetweenSlots,
            _halfRows * slotRectTransform.sizeDelta.y + -_halfCollums * distanceBetweenSlots,
            (collums * slotRectTransform.sizeDelta.x + slotRectTransform.sizeDelta.x + collums * distanceBetweenSlots),
            (rows * slotRectTransform.sizeDelta.y + slotRectTransform.sizeDelta.y * 2 + rows * distanceBetweenSlots + (slotRectTransform.sizeDelta.y * 0.5f)));


		}


	void Update () {
        if (Input.GetMouseButton(0))
        {
            
        }
        //parent_slot.transform.position =;
		parent_slot.transform.position = new Vector3(windowRect.position.x + windowRect.size.x / 2, -windowRect.position.y + windowRect.size.y, 0);
	}

    public static bool IsOdd(int value)
    {
        return value % 2 != 0;
    }

    void OnGUI()
    {
		GUI.backgroundColor = new Color (0, 0, 0, 0);
        windowRect = GUI.Window(0, windowRect, DoMyWindow, "");

    }
    void DoMyWindow(int windowID)
    {
        GUI.DragWindow(new Rect(0, 0, 10000, 50));
    }
}
