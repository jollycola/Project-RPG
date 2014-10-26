using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public KeyCode inventoryKey;
    public GameObject inventorySystem;

	void Start () {
		
	}

	void Update () {
        if (Input.GetKeyDown(inventoryKey))
        {
            if (inventorySystem.activeSelf)
            {
                inventorySystem.SetActive(false);
            }
            else
            {
                inventorySystem.SetActive(true);
            }
            
        }
	}
}
