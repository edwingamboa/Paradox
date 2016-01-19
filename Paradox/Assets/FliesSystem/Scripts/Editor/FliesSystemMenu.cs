using UnityEngine;
using UnityEditor;

public class FliesSystemMenu : Editor {

	static byte count = 0;

	[MenuItem ("GameObject/Create Other/Flies System/Create on Selection")]
	static void CreateOnSelection ()
	{
		if (Selection.activeGameObject != null)
		{
			GameObject go = Selection.activeGameObject;
			go.AddComponent<FliesSystem>();
			Selection.activeTransform = go.transform;
		}
	}
	[MenuItem ("GameObject/Create Other/Flies System/Create on new GameObject")]
	static void CreateOnNew ()
	{
		if (Selection.activeGameObject != null)
		{
			GameObject go = (GameObject)Instantiate(Resources.Load("Flies_System"));

			go.name = "Flies_System_" + count.ToString();
			go.transform.position = Selection.activeTransform.position;
			go.AddComponent<FliesSystem>();
			Selection.activeTransform = go.transform;
			
			++count;
		}
	}
}
