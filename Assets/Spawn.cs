using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	bool okayToDestroy = true;
	// Use this for initialization
	void Start () {
	
	}

	void OnApplicationQuit()
	{
		okayToDestroy = false;
	}
	// Update is called once per frame
	void Update () {
	
	}
	void OnDisable()
	{
		if (okayToDestroy)
		{
			Transform old = transform;
			for (int i = 0; i < 10; i++) 
			{
				GameObject go = (GameObject)Instantiate(Resources.Load("SmallEnemy"));
				go.transform.position = old.position;
			}
		}


	}
}
