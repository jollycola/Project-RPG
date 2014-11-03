using UnityEngine;
using UnityEditor;
using System.Collections;

public class QuestDBManager : EditorWindow {

	[MenuItem("Custom Tools/Quest Database Manager")]

	static void Init(){
		QuestDBManager window = (QuestDBManager)EditorWindow.CreateInstance(typeof(QuestDBManager));
		window.Show();
	}

	void OnGUI(){
		
	}
}
