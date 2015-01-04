using UnityEngine;
using System.Collections;

public class createEnemy : MonoBehaviour {

	// Use this for initialization
	string enemy = "";
	void Start () 
	{
		for (int i = 0; i < 100; i++) 
		{
			int random = Random.Range(1,15);
			if (random == 1)
			{
				enemy = "LargeEnemy";
			}
			else if(random > 1 && random <= 3)
			{
				enemy = "BigEnemy";
			}
			else
			{
				enemy = "SmallEnemy";
			}
			int x = Random.Range(10,-10);
			int y = Random.Range(10,-10);
			GameObject go = (GameObject)Instantiate(Resources.Load(enemy));
			go.transform.position = new Vector3 (x,y,0);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
