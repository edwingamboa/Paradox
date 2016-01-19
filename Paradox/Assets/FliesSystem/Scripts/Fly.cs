using UnityEngine;
using System.Collections;

public class Fly : MonoBehaviour {

	public bool debug;
	public float forwardSpeed;
	public float angularSpeed;
	public Vector3 targetPosition;
	private Transform thisTransform;
	
	void Awake()
	{
		thisTransform = transform;
	}
	public void UpdateMove()
	{
		thisTransform.rotation = Quaternion.Lerp(thisTransform.rotation, Quaternion.LookRotation(targetPosition - thisTransform.position),angularSpeed * Time.deltaTime);
		thisTransform.position += thisTransform.forward * forwardSpeed * Time.deltaTime;

		if(!debug) return;
		Debug.DrawLine(thisTransform.position, targetPosition,Color.white);
	}
}