using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer (typeof (MinMaxSliderAttribute))]
class MinMaxSliderDrawer : PropertyDrawer {
	
	public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) {
		
		if (property.propertyType == SerializedPropertyType.Vector2)
		{
			Vector2 range 	= property.vector2Value;
			float min 		= range.x;
			float max 		= range.y;
			MinMaxSliderAttribute attr = attribute as MinMaxSliderAttribute;

			EditorGUI.BeginChangeCheck ();
			EditorGUILayout.BeginHorizontal();
				EditorGUI.MinMaxSlider (label, new Rect(position.x,position.y,position.width - 106,position.height), ref min, ref max, attr.min, attr.max);
				if (EditorGUI.EndChangeCheck ())
				{
					range.x = min;
					range.y = max;
					property.vector2Value = range; 
				}
			EditorGUI.TextField(new Rect(position.x + position.width-50,position.y,50,position.height),range.y.ToString("0.00"));
			EditorGUI.TextField(new Rect(position.x + position.width-102,position.y,50,position.height),range.x.ToString("0.00"));
			EditorGUILayout.EndHorizontal();

		} else {
			EditorGUI.LabelField (position, label, "Use only with Vector2"); 
		}
	}
}