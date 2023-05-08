using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
	public float speed = 5;

	void update()
	{
		transform.position=new Vector3(0,0,0)+new Vector3(0,0,15);
	}
}
