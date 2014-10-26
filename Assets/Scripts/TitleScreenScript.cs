using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TitleScreenScript : MonoBehaviour {
	void Update () {
		
	}

	public void ButtonClick (string name){
		switch (name) {
		case "start": Application.LoadLevel("GameScene"); break;
		case "exit": Application.Quit(); break;
		}
	}
}
