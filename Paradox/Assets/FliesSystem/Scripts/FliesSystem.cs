using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FliesSystem : MonoBehaviour
{
	public const byte FLY_COUNT_LIMIT = 20;

	public const float RADIUS_LIMIT = 10f;
	public const float DISABLE_LIMIT = 20f;
	public const float UPDATE_TIME_LIMIT = 1f;
	public const float FORWARD_SPEED_LIMIT = 10f;
	public const float ANGULAR_SPEED_LIMIT = 10f;

	public enum ORIENTATION
	{
		Up,
		Down,
		UpDown,
	}

	//public Transform origin;
	public float 	radius = 3f;
	public float	disableDistance = 5f;
	public float	forwardSpeed = 1f;
	public float 	angularSpeed = 1f;
	public float	updateTime = 0.5f;

	public byte 	count = 5;

	public bool		useRandom;
	public bool		useTrail = true;
	public bool		debug;
	public bool		optimize = true;

	public ORIENTATION 	orientation	= ORIENTATION.UpDown;

	[MinMaxSliderAttribute(1f,10f)] public Vector2 randomForward = new Vector2(1f,2f);
	[MinMaxSliderAttribute(1f,10f)] public Vector2 randomAngular = new Vector2(1f,2f);

	private List<Fly> 	list;
	private Transform 	thisTransform;
	private bool 		run;
	private bool 		retarget = false;
	private Color 		gizmoColor = Color.white;
	private Transform 	cameraTransform;
	private bool 		tracking = false;

	void Start()
	{
		list 			= new List<Fly>();
		thisTransform 	= transform;
		cameraTransform = Camera.main.transform;
		Create ();
	}
	public void Create()
	{
		//instantiating the object
		for (byte i = 0; i<count; i++) {

			//creating the FLY object
			GameObject prefab = (GameObject)Instantiate(Resources.Load("Fly"));

			//positioning insite the radius you specified
			prefab.transform.position = thisTransform.position + RandomInsideSphere(); 

			//random rotation to start movement
			prefab.transform.rotation = Quaternion.Euler(new Vector3(RandomInside360(),RandomInside360(),RandomInside360()));

			//setting up the fly component
			Fly f = prefab.GetComponent<Fly>();
			f.forwardSpeed		= (useRandom) ? Random.Range(randomForward.x,randomForward.y) : forwardSpeed;
			f.angularSpeed		= (useRandom) ? Random.Range(randomAngular.x,randomAngular.y) : angularSpeed;
			f.targetPosition 	= thisTransform.position + RandomInsideSphere();
			f.transform.parent 	= thisTransform;
			f.debug				= debug;
			
			//use trail renderer ?
			if(!useTrail) Destroy(f.GetComponent<TrailRenderer>());

			//adding to the list
			list.Add(f);
		}

		run = true;
		StartCoroutine ("Retarget");
	}
	void Update()
	{
		if (run)
		{
			//retargeting (skip after first pass)
			if(retarget)
			{
				retarget = false; //will toggle after the updateTime
				Vector3 p;
				Vector3 offset;

				foreach(Fly i in list)
				{
					p = thisTransform.position + RandomInsideSphere();
					if(orientation != ORIENTATION.UpDown)
					{
						offset	= p - thisTransform.position;
						p.y	= (orientation == ORIENTATION.Up) ? thisTransform.position.y + Mathf.Abs(offset.y) : thisTransform.position.y - Mathf.Abs(offset.y);
					}
					i.targetPosition = p;
					i.UpdateMove();

					if(debug)Debug.DrawLine(transform.position,p,Color.red,updateTime);
				}
				return;
			}

			//updating flies positions
			foreach(Fly j in list)
			{
				j.UpdateMove();
			}
		}
	}

	public void Disable()
	{ 
		enabled = false; 
	}
	public void Enable()
	{ 
		enabled = true;
	}
	void OnBecameInvisible()
	{
		if(!optimize) return;

		if(Distance >= disableDistance)
		{
			Disable();
		}else{
			tracking = true;
		}
	}
	void OnBecameVisible()
	{
		if(!optimize) return;

		tracking = false;
		Enable();
	}
	void OnDrawGizmos()
	{
		if(!debug) return;

		gizmoColor.a = 0.2f;
		Gizmos.color = gizmoColor;
		Gizmos.DrawWireSphere (transform.position, radius);
	}
	private float RandomInside360()
	{ 
		return Random.Range(0,360); 
	}
	private Vector3 RandomInsideSphere()
	{
		return Random.insideUnitSphere * Random.Range(0.1f, radius);
	}
	private float Distance
	{
		get{
			return Vector3.Distance(thisTransform.position,cameraTransform.position);
		}
	}
	
	//function that updates the trajectory of the flies
	//and track the player's distance from the host game object
	IEnumerator Retarget() //its ugly but flexible
	{
		while(run)
		{
			retarget = true;
			if(tracking)
			{
				print("Tracking....");
				if(Distance >= disableDistance)
				{
					print("Distant enough, disabling!");
					tracking = false;
					Disable();
				}
			}
			yield return new WaitForSeconds(updateTime);
		}
	}
}