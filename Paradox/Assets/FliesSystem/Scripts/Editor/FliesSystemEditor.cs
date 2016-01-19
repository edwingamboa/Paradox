using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(FliesSystem))]
public class FliesSystemEditor : Editor {
		
	private SerializedObject instance; 

	private SerializedProperty count;
	private SerializedProperty radius;
	private SerializedProperty disableDistance;
	private SerializedProperty orientation;
	private SerializedProperty updateTime;
	private SerializedProperty forwardSpeed;
	private SerializedProperty angularSpeed;
	private SerializedProperty useTrail;
	private SerializedProperty randomForward;
	private SerializedProperty randomAngular;
	private SerializedProperty useRandom;
	private SerializedProperty debug;
	private SerializedProperty optimize;

	private bool paused;

	public void OnEnable()
	{
		if(instance == null) instance = new SerializedObject(target);

		count 				= instance.FindProperty("count");
		radius 				= instance.FindProperty("radius");
		disableDistance 	= instance.FindProperty("disableDistance");
		orientation		 	= instance.FindProperty("orientation");
		updateTime 			= instance.FindProperty("updateTime");
		forwardSpeed		= instance.FindProperty("forwardSpeed");
		angularSpeed		= instance.FindProperty("angularSpeed");
		randomForward		= instance.FindProperty("randomForward");
		randomAngular		= instance.FindProperty("randomAngular");
		useTrail			= instance.FindProperty("useTrail");
		useRandom			= instance.FindProperty("useRandom");
		debug				= instance.FindProperty("debug");
		optimize			= instance.FindProperty("optimize");
	}

	public override void OnInspectorGUI()
	{
		instance.Update();
		GUILayout.Space(10f);
		EditorGUILayout.BeginHorizontal ();
		if(GUILayout.Button("Randomize",EditorStyles.miniButtonLeft))
		{
			count.intValue 			= Random.Range(5,FliesSystem.FLY_COUNT_LIMIT);
			radius.floatValue 		= Random.Range(1f,FliesSystem.RADIUS_LIMIT);
			updateTime.floatValue 	= Random.Range(0.1f,FliesSystem.UPDATE_TIME_LIMIT);
			forwardSpeed.floatValue = Random.Range(0.5f,FliesSystem.FORWARD_SPEED_LIMIT);
			angularSpeed.floatValue	= Random.Range(0.5f,FliesSystem.ANGULAR_SPEED_LIMIT);
		}

		if(!paused)
		{
			if (GUILayout.Button ("Pause",EditorStyles.miniButtonRight)) {

				if(Application.isPlaying)
				{
					paused = true;
					instance.FindProperty ("m_Enabled").boolValue = false;
				}
			}
		}else{
			if (GUILayout.Button ("Resme",EditorStyles.miniButtonRight)) {
				
				if(Application.isPlaying)
				{
					paused = false;
					instance.FindProperty ("m_Enabled").boolValue = true;
				}
			}
		}
		/*
		if (GUILayout.Button ("Update",EditorStyles.miniButtonRight)) {
			if(Application.isPlaying)
			{
				//to be implemented...
			}
		}
		*/
		EditorGUILayout.EndHorizontal ();

		//----------------
		//	BASIC SETTINGS
		//----------------

		GUILayout.Label("Basic Settings",EditorStyles.boldLabel); 
		EditorGUILayout.IntSlider(count, 1,FliesSystem.FLY_COUNT_LIMIT, "Flies Count");
		EditorGUILayout.Slider(radius,1f,FliesSystem.RADIUS_LIMIT);

		EditorGUILayout.Slider(disableDistance,1f,FliesSystem.DISABLE_LIMIT);
		EditorGUILayout.BeginHorizontal();
			optimize.boolValue = EditorGUILayout.Toggle ("Optimize", optimize.boolValue);
			EditorGUILayout.LabelField("(used for culling optimization)",EditorStyles.miniLabel);
		EditorGUILayout.EndHorizontal();

		EditorGUILayout.BeginHorizontal();
			useTrail.boolValue = EditorGUILayout.Toggle ("Use Trail", useTrail.boolValue);
			EditorGUILayout.LabelField("(you should keep it on, its coolest)",EditorStyles.miniLabel);
		EditorGUILayout.EndHorizontal();

		EditorGUILayout.BeginHorizontal();
			debug.boolValue = EditorGUILayout.Toggle ("Debug", debug.boolValue);
			EditorGUILayout.LabelField("(see the construction lines)",EditorStyles.miniLabel);
		EditorGUILayout.EndHorizontal();

		//------------------
		//ANIMATION SETTINGS
		//------------------
		GUILayout.Space(10f);
		GUILayout.Label ("Animation Settings", EditorStyles.boldLabel); 
		EditorGUILayout.PropertyField(orientation);
		EditorGUILayout.Slider(updateTime,0.1f,FliesSystem.UPDATE_TIME_LIMIT);
		//EditorGUILayout.LabelField("(needs restart)",EditorStyles.miniLabel);

		GUILayout.Space(10f);
		GUILayout.Label ("Per Fly Settings", EditorStyles.boldLabel); 
		EditorGUI.BeginDisabledGroup (useRandom.boolValue);
			EditorGUILayout.Slider(forwardSpeed,0.5f,FliesSystem.FORWARD_SPEED_LIMIT,"Forward Speed");
			EditorGUILayout.Slider(angularSpeed,0.5f,FliesSystem.ANGULAR_SPEED_LIMIT,"Angular Speed");
		EditorGUI.EndDisabledGroup();


		EditorGUI.BeginDisabledGroup (!useRandom.boolValue);			
			EditorGUILayout.PropertyField(randomForward);
			EditorGUILayout.PropertyField(randomAngular);
		EditorGUI.EndDisabledGroup ();
		useRandom.boolValue = EditorGUILayout.Toggle ("Use Random Speed", useRandom.boolValue);



		instance.ApplyModifiedProperties();
	}
}

